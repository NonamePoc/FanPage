﻿using AutoMapper;
using FanPage.Api.Models.Account;
using FanPage.Api.Models.Admin;
using FanPage.Api.Models.Auth;
using FanPage.Api.Models.Fanfic;
using FanPage.Api.ViewModels;
using FanPage.Api.ViewModels.Fanfic;
using FanPage.Api.ViewModels.User;
using FanPage.Application.Account;
using FanPage.Application.Admin;
using FanPage.Application.Auth;
using FanPage.Application.Fanfic;
using FanPage.Domain.Entities.Fanfic;

namespace FanPage.Api.Mapper
{
    public class OutputModelsMapperProfile : Profile
    {
        public OutputModelsMapperProfile()
        {
            RegisterAuthMaps();
            AdminMaps();
            FanficAuthMaps();
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


            CreateMap<FanficCategory, FanficCategoryDto>()
                .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.CategoryId))
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name));
            CreateMap<FanficTag, FanficTagDto>()
                .ForMember(dest => dest.TagId, opt => opt.MapFrom(src => src.TagId))
                .ForMember(dest => dest.TagName, opt => opt.MapFrom(src => src.Tag.Name));
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
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.OriginFandom, opt => opt.MapFrom(src => src.OriginFandom))
                .ForMember(dest => dest.CreationDate, opt => opt.MapFrom(src => src.CreationDate))
                .ForMember(dest => dest.Categories, opt => opt.MapFrom(src => src.FanficCategories))
                .ForMember(dest => dest.Tags, opt => opt.MapFrom(src => src.FanficTags))
                .ForMember(dest => dest.Chapters, opt => opt.MapFrom(src => src.Chapters));

        }
    }
}