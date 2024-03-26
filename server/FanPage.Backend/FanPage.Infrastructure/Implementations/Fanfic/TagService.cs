﻿using AutoMapper;
using FanPage.Application.Fanfic;
using FanPage.Common.Interfaces;
using FanPage.Domain.Fanfic.Repos.Interfaces;
using FanPage.Exceptions;
using FanPage.Infrastructure.Interfaces.Fanfic;
using FanPage.Infrastructure.Interfaces.User;
using Microsoft.AspNetCore.Http;

namespace FanPage.Infrastructure.Implementations.Fanfic;

public class TagService : ITag
{
    private readonly ITagRepository _tagRepository;

    private readonly IFanficRepository _fanficRepository;

    private readonly IJwtTokenManager _jwtTokenManager;

    private readonly IAdmin _admin;

    private readonly IMapper _mapper;

    public TagService(ITagRepository tagRepository, IFanficRepository fanficRepository,
        IJwtTokenManager jwtTokenManager, IMapper mapper, IAdmin admin)
    {
        _tagRepository = tagRepository;
        _fanficRepository = fanficRepository;
        _jwtTokenManager = jwtTokenManager;
        _mapper = mapper;
        _admin = admin;
    }

    public async Task<TagDto> CreateTagAsync(int fanficId, TagDto tagDto, HttpRequest request)
    {
        var fanfic = await _fanficRepository.GetByIdAsync(fanficId);
        var userName = _jwtTokenManager.GetUserNameFromToken(request);
        if (fanfic.AuthorName != userName && fanfic == null)
        {
            throw new FanficException("Error update");
        }

        var tagAlready = await _tagRepository.GetByNameAsync(tagDto.Name);

        if (tagAlready != null)
        {
            throw new FanficException("Tag already exist");
        }

        var result = await _tagRepository.CreateAsync(tagDto);

        return new TagDto()
        {
            TagId = result.TagId,
            Name = result.Name
        };
    }

    public async Task<TagDto> SetTagAsync(int fanficId, string? name, HttpRequest request)
    {
        var fanfic = await _fanficRepository.GetByIdAsync(fanficId);
        var userName = _jwtTokenManager.GetUserNameFromToken(request);
        var tag = await _tagRepository.GetByNameAsync(name);
        var tagAlreadyFanfic = await _tagRepository.GetTagByFanficIdAsync(fanficId, tag.TagId);

        if (fanfic.AuthorName != userName && fanfic == null)
        {
            throw new FanficException("Error update");
        }

        if (tagAlreadyFanfic != null)
        {
            throw new FanficException("Tag already exist");
        }

        if (tag == null)
        {
            throw new FanficException("Tag not found");
        }

        var tagId = tag.TagId;
        await _tagRepository.AddTagToFanficAsync(fanficId, tagId);

        return new TagDto()
        {
            TagId = tag.TagId,
            Name = tag.Name
        };
    }


    public async Task<TagDto> DeleteTagFanficAsync(int fanficId, string? tagName, HttpRequest request)
    {
        var fanfic = await _fanficRepository.GetByIdAsync(fanficId);
        var userName = _jwtTokenManager.GetUserNameFromToken(request);
        var tag = await _tagRepository.GetByNameAsync(tagName);

        if (fanfic.AuthorName != userName && fanfic == null)
        {
            throw new FanficException("Error update");
        }

        await _tagRepository.DeleteTagFromFanficAsync(fanficId, tagName);

        return new TagDto()
        {
            TagId = tag.TagId,
            Name = tagName
        };
    }

    public async Task DeleteTagAsync(int tagId, HttpRequest request)
    {
        var tag = await _tagRepository.GetByIdAsync(tagId);
        var admin = await _admin.GetAdminAsync(request);
        if (admin.Role != "Admin")
        {
            throw new FanficException("Not permission to delete tag");
        }

        if (tag == null)
        {
            throw new FanficException("Error update");
        }

        await _tagRepository.DeleteAsync(tagId);
    }

    public async Task<List<TagDto>> GetAllTagFanfic(int fanficId)
    {
        var tags = await _tagRepository.GetTagsByFanficIdAsync(fanficId);
        return _mapper.Map<List<TagDto>>(tags);
    }

    public async Task<List<TagDto>> GetAllTagAsync()
    {
        var tags = await _tagRepository.GetAllAsync();
        return _mapper.Map<List<TagDto>>(tags);
    }
}