using Microsoft.Extensions.DependencyInjection;
using OC.Application.Interfaces.Repositories;
using OC.Infra.Interfaces.DefaultRepositories;
using OC.Infra.Repositories;
using OC.Infra.Repositories.DefaultRepositores;

namespace OC.Infra
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDefaultInfra(
            this IServiceCollection services
            /*IConfiguration configuration*/
        )
        {
            services.AddScoped(typeof(IDefaultCreateRepository<>), typeof(DefaultCreateRepository<>));
            services.AddScoped(typeof(IDefaultGetRepository<>), typeof(DefaultGetRepository<>));
            services.AddScoped(typeof(IDefaultFilterRepository<>), typeof(DefaultFilterRepository<>));
            services.AddScoped(typeof(IDefaultUpdateRepository<>), typeof(DefaultUpdateRepository<>));

            services.AddInfra();

            return services;
        }

        public static IServiceCollection AddInfra(
            this IServiceCollection services
            /*IConfiguration configuration*/
        )
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserTypeChannelRepository, UserTypeChannelRepository>();

            return services;
        }
    }
}
