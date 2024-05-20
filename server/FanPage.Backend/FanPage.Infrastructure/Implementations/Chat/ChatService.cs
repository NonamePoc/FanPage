﻿using FanPage.Application.Chat;
using FanPage.Common.Interfaces;
using FanPage.Domain.Account.Entities;
using FanPage.Domain.Chat.Entities;
using FanPage.Domain.Chat.Repos.Interface;
using FanPage.Exceptions;
using FanPage.Infrastructure.Implementations.Helper;
using FanPage.Infrastructure.Interfaces.Chat;
using FanPage.Infrastructure.Interfaces.User;
using Microsoft.AspNetCore.Http;
using System;

namespace FanPage.Infrastructure.Implementations.Chat;

public class ChatService : IChat
{
    private readonly IAdmin _admin;
    private readonly IChatRepository _chatRepository;
    private readonly IJwtTokenManager _jwtTokenManager;
    private readonly IStorageHttp _storageHttp;
    private readonly IdentityUserManager _userManager;

    public ChatService(
        IChatRepository chatRepository,
        IJwtTokenManager jwtTokenManager,
        IAdmin admin,
        IdentityUserManager userManager,
        IStorageHttp storageHttp
    )
    {
        _chatRepository = chatRepository;
        _jwtTokenManager = jwtTokenManager;
        _admin = admin;
        _userManager = userManager;
        _storageHttp = storageHttp;
    }

    public async Task AcceptUserToChatAsync(int chatId, HttpRequest request)
    {
        try
        {
            var userNameFromToken = _jwtTokenManager.GetUserNameFromToken(request);
            var chatRequest = await _chatRepository.GetChatRequestAsync(userNameFromToken);
            var chat = chatRequest.FirstOrDefault(x => x.Id == chatId);
            if (chat == null)
            {
                throw new ChatException($"Error Chat");
            }

            if (userNameFromToken == null)
            {
                throw new ChatException($"Error Chat");
            }

            await _chatRepository.AcceptUserToChatAsync(chatId, userNameFromToken);
        }
        catch (Exception e)
        {
            throw new ChatException("Error Accept User to chat: " + e.Message);
        }
    }

    public async Task<ChatDto> CreateAsync(ChatDto chat, HttpRequest request)
    {
        try
        {
            chat.Type = "public";
            var userName = _jwtTokenManager.GetUserNameFromToken(request);
            var userId = _jwtTokenManager.GetUserIdFromToken(request);
            var usersList = chat.ChatUsers.ToList();

            if (userName == null)
            {
                throw new ChatException($"Error Chat");
            }

            chat.AuthorName = userName;

            var chatExist = await _chatRepository.IsNameExistAsync(chat.Name, "public");
            if (chatExist)
            {
                throw new ChatException($"Chat with this name already exists");
            }


            var chatEntity = await _chatRepository.CreateAsync(chat);

            await _chatRepository.AddUserToChatAsync(chatEntity.Id, userId, userName);


            var usersTasks = usersList
                .Select(async usersChat =>
                {
                    var user = await _userManager.FindByNameAsync(usersChat.UserName);
                    if (user != null)
                    {
                        usersChat.UserId = user.Id;
                        usersChat.Avatar = await _storageHttp.GetImageBase64FromStorageService(user.UserAvatar);
                        usersChat.ChatId = chatEntity.Id;
                        if (chatEntity.AuthorName == userName)
                        {
                            usersChat.AcceptedRequest = true;
                        }
                    }
                });

            await Task.WhenAll(usersTasks);

            var listChatUser = usersList.Where(u => u.UserId != null).ToList();

            await _chatRepository.InviteUserToChatAsync(chatEntity.Id, listChatUser);

            return new ChatDto
            {
                Id = chatEntity.Id,
                Type = chatEntity.Type,
                Name = chatEntity.Name,
                Description = chatEntity.Description,
                AuthorName = chatEntity.AuthorName,
                FriendId = "",
                ChatUsers = listChatUser,
                Messages = new List<MessageDto>()
            };
        }
        catch (Exception e)
        {
            throw new ChatException("Error creating chat: " + e.Message);
        }
    }


    public async Task<MessageDto> CreateMessageAsync(
        int chatId,
        MessageDto message,
        HttpRequest request
    )
    {
        try
        {
            var userId = _jwtTokenManager.GetUserIdFromToken(request);
            var userName = _jwtTokenManager.GetUserNameFromToken(request);
            var chat = await _chatRepository.GetByIdAsync(chatId, 1, 1);
            if (userId == null || chat == null)
            {
                throw new ChatException($"Error Chat");
            }

            message.ChatId = chatId;
            message.ReceivedDateUtc = DateTimeOffset.UtcNow;
            message.UserId = userId;

            var user = await _userManager.FindByIdAsync(userId);

            var userAvatar = await _storageHttp.GetImageBase64FromStorageService(user.UserAvatar);

            await _chatRepository.CreateMessageAsync(chatId, message);

            return new MessageDto
            {
                Content = message.Content,
                ReceivedDateUtc = DateTime.UtcNow,
                ChatId = chat.Id,
                UserId = userId,
                SenderAvatar = userAvatar,
                UserName = userName
            };
        }
        catch (Exception e)
        {
            throw new ChatException("Error add message to chat: " + e.Message);
        }
    }

    public async Task DeclineUserToChatAsync(int chatId, HttpRequest request)
    {
        try
        {
            var userNameFromToken = _jwtTokenManager.GetUserNameFromToken(request);
            var chatRequest = await _chatRepository.GetChatRequestAsync(userNameFromToken);
            var chat = chatRequest.FirstOrDefault(x => x.Id == chatId);
            if (chat == null)
            {
                throw new ChatException($"Error Chat");
            }

            if (userNameFromToken == null)
            {
                throw new ChatException($"Error Chat");
            }

            await _chatRepository.DeclineUserToChatAsync(chatId, userNameFromToken);
        }
        catch (Exception e)
        {
            throw new ChatException("Error decline user to chat: " + e.Message);
        }
    }

    public async Task DeleteAsync(int id, HttpRequest request)
    {
        try
        {
            var userName = _jwtTokenManager.GetUserNameFromToken(request);
            var chat = await _chatRepository.GetByIdAsync(id, 1, 1);
            if (chat == null)
            {
                throw new ChatException($"Chat with id {id} not found.");
            }

            if (chat.AuthorName != userName)
            {
                throw new ChatException($"Not permission to delete chat");
            }

            await _chatRepository.DeleteAsync(id);
        }
        catch (Exception e)
        {
            throw new ChatException("Error deleting chat: " + e.Message);
        }
    }

    public async Task<ChatDto> GetChatAsync(int id, int messagePage, int userPage, HttpRequest request)
    {
        try
        {
            var userName = _jwtTokenManager.GetUserNameFromToken(request);
            if (userName == null)
            {
                throw new ChatException("Error: User not authenticated");
            }

            var resultList = new List<ChatDto>();
            var chatUsers = await _chatRepository.PrivateGetChatUsersAsync(id);
            var chat = await _chatRepository.GetByIdAsync(id, userPage, messagePage);

            var userTasks = chatUsers.Select(async chatUser =>
            {
                var user = await _userManager.FindByIdAsync(chatUser.UserId);
                return (chatUser, user);
            }).ToList();

            await Task.WhenAll(userTasks);

            foreach (var (chatUser, user) in userTasks.Select(t => t.Result))
            {
                if (user == null)
                {
                    continue;
                }

                var userAvatar = await _storageHttp.GetImageBase64FromStorageService(user.UserAvatar);

                resultList.Add(new ChatDto
                {
                    Id = chat.Id,
                    Type = chat.Type,
                    Name = chat.Name,
                    ChatUsers = chatUsers
                        .Select(cu => new ChatUserDto
                        {
                            ChatId = chat.Id,
                            UserId = cu.UserId,
                            UserName = cu.UserName,
                            Avatar = cu.UserId == user.Id ? userAvatar : null,
                            AcceptedRequest = true
                        })
                        .ToList(),
                    Messages = chat.Messages
                        .Select(m => new MessageDto
                        {
                            Content = m.Content,
                            ReceivedDateUtc = m.ReceivedDateUtc,
                            UserId = m.UserId,
                            SenderAvatar = m.UserId == user.Id ? userAvatar : null
                        })
                        .OrderByDescending(m => m.ReceivedDateUtc)
                        .ToList(),
                    AuthorName = chat.AuthorName,
                    Description = chat.Description
                });
            }

            if (resultList.Count == 0)
            {
                throw new ChatException("Error: Chat not found");
            }
            return resultList.FirstOrDefault();
        }
        catch (Exception e)
        {
            throw new Exception("Error GetChat: " + e.Message);
        }
    }

    public async Task<List<ChatDto>> GetChatRequestAsync(HttpRequest request)
    {
        try
        {
            var userNameFromToken = _jwtTokenManager.GetUserNameFromToken(request);
            if (userNameFromToken == null)
            {
                throw new ChatException($"Error username token is null");
            }

            var chats = await _chatRepository.GetChatRequestAsync(userNameFromToken);

            return chats
                .Select(c => new ChatDto
                {
                    Id = c.Id,
                    Type = c.Type,
                    Name = c.Name,
                    Description = c.Description,
                    AuthorName = c.AuthorName,
                    ChatUsers = new List<ChatUserDto>(),
                    Messages = new List<MessageDto>()
                })
                .ToList();
        }
        catch (Exception e)
        {
            throw new Exception("Error get chat request: " + e.Message);
        }
    }

    public async Task<List<ChatDto>> GetChatsUser(int offset, int page, HttpRequest request)
    {
        try
        {
            var userName = _jwtTokenManager.GetUserNameFromToken(request);
            if (userName == null)
            {
                throw new ChatException($"Username is null");
            }

            var result = await _chatRepository.GetChatsUserAsync(userName, offset, page);

            return result
                .Select(c => new ChatDto
                {
                    Id = c.Id,
                    Type = c.Type,
                    Name = c.Name,
                    Description = c.Description,
                    AuthorName = c.AuthorName,
                    ChatUsers = new List<ChatUserDto>(),
                    Messages = new List<MessageDto>()
                })
                .ToList();
        }
        catch (Exception e) { throw new Exception("Error get chats: " + e.Message); }
    }

    public async Task<List<ChatDto>> GetGlobalChats(int offset, int page, HttpRequest request)
    {
        try
        {
            var userName = _jwtTokenManager.GetUserNameFromToken(request);
            if (userName == null)
            {
                throw new ChatException($"Username is null");
            }

            var chats = await _chatRepository.GetGlobalChatsAsync(offset, page);

            return chats
                .Select(c => new ChatDto
                {
                    Id = c.Id,
                    Type = c.Type,
                    Name = c.Name,
                    Description = c.Description,
                    AuthorName = c.AuthorName,
                    ChatUsers = new List<ChatUserDto>(),
                    Messages = new List<MessageDto>()
                })
                .ToList();
        }
        catch (Exception e) { throw new Exception("Error get global chats: " + e.Message); }
    }

    public async Task InviteUserToChatAsync(int chatId, List<ChatUserDto> chatUsers, HttpRequest request)
    {
        try
        {
            var userNameFromToken = _jwtTokenManager.GetUserNameFromToken(request);
            var userDtos = new List<ChatUserDto>();

            var usersTasks = chatUsers
              .Select(async usersChat =>
              {
                  var user = await _userManager.FindByNameAsync(usersChat.UserName);
                  if (user != null)
                  {
                      usersChat.UserId = user.Id;
                      usersChat.Avatar = await _storageHttp.GetImageBase64FromStorageService(user.UserAvatar);
                      usersChat.ChatId = chatId;
                      usersChat.AcceptedRequest = false;
                  }
              });

            await Task.WhenAll(usersTasks);


            var listChatUser = chatUsers.Where(u => u.UserId != null).ToList();

            await _chatRepository.InviteUserToChatAsync(chatId, listChatUser);
        }
        catch (Exception ex)
        {
            throw new ChatException("Error inviting users to chat: " + ex.Message);
        }
    }


    public async Task RemoveUserFromChatAsync(
        int chatId,
        string userChatName,
        HttpRequest request
    )
    {
        try
        {
            var userName = _jwtTokenManager.GetUserNameFromToken(request);
            var userRole = await _admin.GetUserRoleAsync(userName);
            var chatEntity = await _chatRepository.GetChatAsync(chatId);
            if (
                userRole.Role != "Admin"
                && userRole.Role != "Moderator"
                && chatEntity.AuthorName != userName
            )
            {
                throw new ChatException($"Not permission to update chat");
            }

            await _chatRepository.RemoveUserFromChatAsync(chatId, userChatName);
        }
        catch (Exception ex)
        {
            throw new ChatException("Error remove user to chat" + ex.Message);
        }
    }

    public async Task<List<ChatDto>> SearchChatAsync(string search, HttpRequest request)
    {
        try
        {
            var username = _jwtTokenManager.GetUserNameFromToken(request);
            var chatSearch = await _chatRepository.SearchChatAsync(search, username);
            return chatSearch;
        }
        catch (Exception e)
        {
            throw new ChatException("Error search chat: " + e.Message);
        }
    }

    public async Task<ChatDto> UpdateAsync(int chatId, ChatDto chat, HttpRequest request)
    {
        try
        {
            var userName = _jwtTokenManager.GetUserNameFromToken(request);
            var userRole = await _admin.GetUserRoleAsync(userName);
            var chatEntity = await _chatRepository.GetChatAsync(chatId);

            if (
                userRole.Role != "Admin"
                && userRole.Role != "Moderator"
                && chatEntity.AuthorName != userName
            )
            {
                throw new ChatException($"Not permission to update chat");
            }

            chatEntity.Name = chat.Name ?? chatEntity.Name;
            chatEntity.Description = chat.Description ?? chatEntity.Description;
            chatEntity.Type = chat.Type ?? chatEntity.Type;

            var result = await _chatRepository.UpdateAsync(chatId, chat);

            return new ChatDto
            {
                Id = result.Id,
                Type = result.Type,
                Name = result.Name,
                Description = result.Description,
                AuthorName = result.AuthorName,
            };
        }
        catch (Exception e)
        {
            throw new ChatException("Error update chat: " + e.Message);
        }
    }
}