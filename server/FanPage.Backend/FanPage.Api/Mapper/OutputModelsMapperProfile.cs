﻿using AutoMapper;
using FanPage.Api.Models.Account;
using FanPage.Api.Models.Auth;
using FanPage.Api.ViewModels;
using FanPage.Application.Account;
using FanPage.Application.Auth;

namespace FanPage.Api.Mapper
{
    public class OutputModelsMapperProfile : Profile
    {
        public OutputModelsMapperProfile() {
            RegisterAuthMaps();
        }
        private void RegisterAuthMaps()
        {
            CreateMap<LogInResponseDto, LogInViewModel>();

            CreateMap<RefreshTokenDto, RefreshTokenViewModel>();
            CreateMap<RegistrationModel, RegistrationDto>();
            CreateMap<ConfirmEmailModel, ConfirmEmailDto>();
            CreateMap<AuthModel, AuthDto>();
            CreateMap<RestorePasswordModel,RestorePasswordDto>();
            CreateMap<RequestToRestorePassModel, RequestRestorePasswordDto>();
            CreateMap<PasswordChangeModel, ChangePasswordDto>();
        }
    }
}