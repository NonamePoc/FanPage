#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["FanPage.Api/FanPage.Api.csproj", "FanPage.Api/"]
COPY ["FanPage.Backend.ServiceDefaults/FanPage.Backend.ServiceDefaults.csproj", "FanPage.Backend.ServiceDefaults/"]
COPY ["FanPage.Common/FanPage.Common.csproj", "FanPage.Common/"]
COPY ["FanPage.Domain.Account/FanPage.Domain.Account.csproj", "FanPage.Domain.Account/"]
COPY ["FanPage.Application/FanPage.Application.csproj", "FanPage.Application/"]
COPY ["FanPage.Domain.Fanfic/FanPage.Domain.Fanfic.csproj", "FanPage.Domain.Fanfic/"]
COPY ["FanPage.Exception/FanPage.Exceptions.csproj", "FanPage.Exception/"]
COPY ["FanPage.Domain.Chat/FanPage.Domain.Chat.csproj", "FanPage.Domain.Chat/"]
COPY ["FanPage.Infrastructure/FanPage.Infrastructure.csproj", "FanPage.Infrastructure/"]
COPY ["FanPage.EmailService/FanPage.EmailService.csproj", "FanPage.EmailService/"]
RUN dotnet restore "./FanPage.Api/FanPage.Api.csproj"
COPY . .
WORKDIR "/src/FanPage.Api"
RUN dotnet build "./FanPage.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./FanPage.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FanPage.Api.dll"]