using AutoMapper;
using FanPage.Api.Models.Account;
using FanPage.Api.Models.Admin;
using FanPage.Api.Models.Auth;
using FanPage.Api.Models.Fanfic;
using FanPage.Api.ViewModels.Fanfic;
using FanPage.Api.ViewModels.User;
using FanPage.Application.Account;
using FanPage.Application.Admin;
using FanPage.Application.Auth;
using FanPage.Application.Fanfic;
using FanPage.Application.UserProfile;
using FanPage.Domain.Account.Entities;
using FanPage.Domain.Fanfic.Entities;

namespace FanPage.Api.Mapper
{
    public class OutputModelsMapperProfile : Profile
    {
        public OutputModelsMapperProfile()
        {
            RegisterAuthMaps();
            AdminMaps();
            FanficAuthMaps();
            ProfileMaps();
        }

        private void RegisterAuthMaps()
        {
            CreateMap<LogInResponseDto, LogInViewModel>();

            CreateMap<RefreshTokenDto, RefreshTokenViewModel>();
            CreateMap<RegistrationModel, RegistrationDto>();
            CreateMap<ConfirmEmailModel, ConfirmEmailDto>();
            CreateMap<AuthModel, AuthDto>();
            CreateMap<RestorePasswordModel, RestorePasswordDto>();
            CreateMap<RequestToRestorePassModel, RequestRestorePasswordDto>();
            CreateMap<PasswordChangeModel, ChangePasswordDto>();
        }

        private void AdminMaps()
        {
            CreateMap<BanModel, BanDto>();
            CreateMap<ChangeRoleModel, ChangeRoleDto>();
            CreateMap<UserInfoResponseDto, UserInfoViewModel>();
        }

        private void ProfileMaps()
        {
            CreateMap<Friendship, FriendDto>();
            CreateMap<FriendRequest, FriendRequestDto>();
            CreateMap<Follower, FollowerDto>();
            CreateMap<Bookmark, BookmarkDto>();
        }


        private void FanficAuthMaps()
        {
            // fanfic
            CreateMap<CreateModel, CreateDto>();
            CreateMap<FanficDto, FanficViewModel>();
            CreateMap<UpdateDto, Fanfic>();
            CreateMap<UpdateModel, UpdateDto>();

            // photo
            CreateMap<FanficPhotoDto, FanficPhoto>();
            CreateMap<FanficPhotoModel, FanficPhotoDto>();

            // chapter
            CreateMap<ChapterModel, ChapterDto>();
            CreateMap<ChapterDto, Chapter>();
            CreateMap<ChapterDto, ChapterViewModel>();

            // review
            CreateMap<ReviewModel, ReviewsDto>();
            CreateMap<ReviewsDto, Reviews>();
            CreateMap<Reviews, ReviewsDto>();
            CreateMap<ReviewsDto, ReviewViewModel>();

            // category
            CreateMap<CategoryDto, CategoryViewModel>();
            CreateMap<Category, CategoryDto>();
            CreateMap<FanficCategory, CategoryDto>();
            CreateMap<FanficCategoryModel, FanficCategoryDto>();
            // tag
            CreateMap<TagDto, Tag>();
            CreateMap<TagModel, TagDto>();
            CreateMap<TagDto, TagViewModel>();
            CreateMap<Tag, TagDto>();
            CreateMap<FanficTag, TagDto>();

            CreateMap<Category, CategoryDto>();
            CreateMap<Tag, TagDto>();
            CreateMap<CreateModel, CreateDto>()
                .ForMember(dest => dest.Categories, opt => opt.MapFrom(src => src.Categories))
                .ForMember(dest => dest.Tags, opt => opt.MapFrom(src => src.Tags));


            CreateMap<List<Tag>, List<TagDto>>()
                .ConvertUsing(tags => tags.Select(tag => new TagDto
                {
                    TagId = tag.TagId,
                    Name = tag.Name,
                    IsApproved = tag.IsApproved
                }).ToList());

            CreateMap<Reviews, ReviewsDto>()
                .ForMember(dest => dest.FanficId, opt => opt.MapFrom(src => src.FanficId))
                .ForMember(dest => dest.ReviewId, opt => opt.MapFrom(src => src.ReviewId))
                .ForMember(dest => dest.Text, opt => opt.MapFrom(src => src.Text))
                .ForMember(dest => dest.CreationDate, opt => opt.MapFrom(src => src.CreationDate))
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName))
                .ForMember(dest => dest.Rating, opt => opt.MapFrom(src => src.Rating));

            CreateMap<FanficCategory, FanficCategoryDto>()
                .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.CategoryId))
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name));
            CreateMap<FanficTag, TagDto>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Tag.Name))
                .ForMember(dest => dest.TagId, opt => opt.MapFrom(src => src.TagId))
                .ForMember(dest => dest.IsApproved, opt => opt.MapFrom(src => src.Tag.IsApproved));

            CreateMap<Chapter, ChapterDto>()
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
                .ForMember(dest => dest.Content, opt => opt.MapFrom(src => src.Content));


            CreateMap<CreateDto, Fanfic>()
                .ForMember(dest => dest.AuthorName, opt => opt.MapFrom(src => src.AuthorName))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.OriginFandom, opt => opt.MapFrom(src => src.OriginFandom))
                .ForMember(dest => dest.Language, opt => opt.MapFrom(src => src.Language))
                .ForMember(dest => dest.Stage, opt => opt.MapFrom(src => src.Stage));
            CreateMap<Fanfic, FanficDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.FanficId))
                .ForMember(dest => dest.AuthorName, opt => opt.MapFrom(src => src.AuthorName))
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.OriginFandom, opt => opt.MapFrom(src => src.OriginFandom))
                .ForMember(dest => dest.CreationDate, opt => opt.MapFrom(src => src.CreationDate))
                .ForMember(dest => dest.Categories, opt => opt.MapFrom(src => src.FanficCategories))
                .ForMember(dest => dest.Tags, opt => opt.MapFrom(src => src.FanficTags))
                .ForMember(dest => dest.Chapters, opt => opt.MapFrom(src => src.Chapters));
        }
    }
}