using System.IdentityModel.Tokens.Jwt;
using System.Text;
using AutoMapper;
using FanPage.Api.Mapper;
using FanPage.Api.Middleware;
using FanPage.Api.Swagger;
using FanPage.Common.Configurations;
using FanPage.Common.Implementations;
using FanPage.Common.Interfaces;
using FanPage.Domain.Configurations;
using FanPage.Domain.Entities.Identity;
using FanPage.Domain.Enum;
using FanPage.EmailService.Configuration;
using FanPage.EmailService.Interfaces;
using FanPage.Infrastructure.Implementations;
using FanPage.Infrastructure.Implementations.Fanfic;
using FanPage.Infrastructure.Implementations.User;
using FanPage.Infrastructure.Interfaces;
using FanPage.Infrastructure.Interfaces.Fanfic;
using FanPage.Infrastructure.Interfaces.User;
using FanPage.Persistence.Context;
using FanPage.Persistence.Repositories.Implementations.FanficRepos;
using FanPage.Persistence.Repositories.Implementations.IdentityRepos;
using FanPage.Persistence.Repositories.Interfaces;
using FanPage.Persistence.Repositories.Interfaces.IFanfic;
using FanPage.Persistence.Repositories.Interfaces.IIdentity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using PasswordGenerator;

namespace FanPage.Api.Configure
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection DataBase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton(configuration.GetSection("DefaultUserConfiguration").Get<DefaultUserConfiguration>());

            services.AddDbContext<UserContext>(optionsAction =>
            {
                optionsAction.UseNpgsql(configuration.GetConnectionString("User-Connection"))
                    .UseLoggerFactory(new LoggerFactory());
            });

            services.AddIdentity<User, IdentityRole>(options => { })
                .AddEntityFrameworkStores<UserContext>()
                .AddDefaultTokenProviders();

            services.AddDbContext<FanficContext>(optionsAction => optionsAction
                .UseNpgsql(configuration.GetConnectionString("Fanfik-Connection")));

            services.AddScoped<IdentityUserManager>();

            services.AddIdentityCore<User>(opts =>
                {
                    opts.Password.RequireDigit = true;
                    opts.Password.RequireLowercase = true;
                    opts.Password.RequireUppercase = true;
                    opts.Password.RequireNonAlphanumeric = true;
                    opts.User.RequireUniqueEmail = true;
                    opts.User.AllowedUserNameCharacters = null;
                })
                .AddRoles<IdentityRole>()
                .AddSignInManager()
                .AddDefaultTokenProviders()
                .AddEntityFrameworkStores<UserContext>();

            return services;
        }

        public static IServiceCollection ConfigureRepository(this IServiceCollection services)
        {
            services.AddScoped<IFanficRepository, FanficRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ITagRepository, TagRepository>();
            services.AddScoped<IFanficPhotoRepository, FanficPhotoRepository>();
            services.AddScoped<IFanficCommentRepository, FanficCommentPhotoRepository>();
            services.AddScoped<IUserPhotoRepository, UserPhotoRepository>();
            services.AddScoped<IChapterRepository, ChapterRepository>();
            return services;
        }

        public static IServiceCollection Logger(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<LoggingConfiguration>(configuration.GetSection("Logging"));
            services.AddScoped<LoggingService>();
            return services;
        }

        public static IApplicationBuilder UseApiLogging(this IApplicationBuilder app)
        {
            app.Use(async (context, next) =>
            {
                var loggingService = context.RequestServices.GetRequiredService<LoggingService>();
                loggingService.LogApiRequest(context);
                await next();
                loggingService.LogApiResponse(context);
            });

            return app;
        }

        public static IServiceCollection ConfigureAuthentication(this IServiceCollection services,
            IConfiguration configuration)
        {
            var jwtConfig = configuration.GetSection("JwtConfiguration").Get<JwtConfiguration>();

            services.AddSingleton<IPasswordSettings>(s =>
                new UserPasswordSettings(true, true, true, true, 16, int.MaxValue, false));
            services.AddSingleton<IPasswordManager, PasswordManager>();

            services.AddSingleton(jwtConfig);
            services.AddSingleton<JwtSecurityTokenHandler>();

            services.AddScoped<JwtValidationMiddleware>();
            services.AddScoped<IJwtGenerator, JwtGenerator>();
            services.AddScoped<IJwtTokenManager, JwtTokenManager>();

            services.AddScoped<CustomizationSettingsService>();

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtConfig.Key));
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(
                    opt =>
                    {
                        opt.TokenValidationParameters = new TokenValidationParameters
                        {
                            ValidateIssuerSigningKey = true,
                            IssuerSigningKey = key,
                            ValidateAudience = false,
                            ValidateIssuer = false,
                            ClockSkew = TimeSpan.Zero
                        };

                        opt.Events = new JwtBearerEvents
                        {
                            OnAuthenticationFailed = context =>
                            {
                                if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
                                    context.Response.Headers.Add("Token-Expired", "true");

                                return Task.CompletedTask;
                            }
                        };
                    });

            return services;
        }

        public static IServiceCollection ConfigureMapper(this IServiceCollection services)
        {
            services.AddSingleton(new MapperConfiguration(mc =>
                {
                    mc.AddProfiles(new Profile[]
                    {
                        new OutputModelsMapperProfile(),
                    });
                })
                .CreateMapper());

            return services;
        }

        public static IServiceCollection ConfigureBusinessServices(this IServiceCollection services)
        {
            services.AddScoped<IAccount, AccountServiсe>();
            services.AddScoped<IAuth, AuthService>();
            services.AddScoped<IFanfic, FanficService>();
            services.AddScoped<IFanficDetail, FanficDetailService>();
            services.AddScoped<ICategory, CategoryService>();
            services.AddScoped<ITag, TagService>();
            services.AddScoped<IChapter, ChapterService>();
            services.AddScoped<IReview, ReviewService>();
            return services;
        }

        public static IServiceCollection ConfigureApplication(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddSingleton(configuration.GetSection("ApplicationConfiguration").Get<ApplicationConfiguration>());
            return services;
        }

        public static IServiceCollection ConfigureSmtp(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddSingleton(configuration.GetSection("SmtpConfiguration").Get<SmtpConfiguration>());
            services.AddSingleton<IEmailService, FanPage.EmailService.Implementations.EmailService>();

            //services.AddHostedService<SmtpConsumerRabbitHostedServices>();
            return services;
        }

        public static IServiceCollection ConfigureSwagger(
            this IServiceCollection services,
            IConfiguration configuration,
            OpenApiInfo info)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(info.Version, info);
                c.DocumentFilter<EnumDescriptionFilter>();
                c.AddSecurityDefinition("bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme. Set `Bearer ` before ur `Token`",
                });

                c.OperationFilter<AuthOperationFilter>();
            });

            services.Configure<SwaggerConfig>(configuration);
            return services;
        }

        public static void SeedIdentity(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();
            var serviceProvider = scope.ServiceProvider;

            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            foreach (var roleName in Enum.GetNames(typeof(UserRole)))
                if (!roleManager.RoleExistsAsync(roleName).GetAwaiter().GetResult())
                    roleManager.CreateAsync(new IdentityRole(roleName)).GetAwaiter().GetResult();

            var userManager = serviceProvider.GetRequiredService<IdentityUserManager>();

            if (userManager.Users.Any())
                return;

            var configuration = serviceProvider.GetRequiredService<DefaultUserConfiguration>();

            var user = new User
            {
                Email = configuration.Email,
                UserName = configuration.UserName,
                EmailConfirmed = true
            };

            userManager.CreateAsync(user, configuration.Password).GetAwaiter().GetResult();

            userManager.AddToRoleAsync(user, nameof(UserRole.User)).GetAwaiter().GetResult();
        }
    }
}