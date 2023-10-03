using FanPage.Domain.Identity;
using FanPage.Persistence.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace FanPage.Api.Configure
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection DataBase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<UserContext>(optionsAction => optionsAction
            .UseNpgsql(configuration.GetConnectionString("User-Connection")));

            services.AddIdentity<User, IdentityRole>(options => { })
                .AddEntityFrameworkStores<UserContext>()
                .AddDefaultTokenProviders();

            services.AddDbContext<FanfikContext>(optionsAction => optionsAction
            .UseNpgsql(configuration.GetConnectionString("Fanfik-Connection")));

            return services;
        }
    }
}
