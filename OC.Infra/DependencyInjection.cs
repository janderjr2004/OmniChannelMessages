using Microsoft.Extensions.DependencyInjection;
using OC.Application.Interfaces.Factories;
using OC.Application.Interfaces.Repositories;
using OC.Application.Interfaces.Services;
using OC.Infra.Interfaces.DefaultRepositories;
using OC.Infra.Repositories;
using OC.Infra.Repositories.DefaultRepositores;
using OC.Infra.Services;
using OC.Libraries.Factories.MessagesFactory;

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

            services.AddInfraRepositories();
            services.AddInfraServices();

            return services;
        }

        public static IServiceCollection AddInfraRepositories(
            this IServiceCollection services
            /*IConfiguration configuration*/
        )
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserTypeChannelRepository, UserTypeChannelRepository>();

            return services;
        }        
        
        public static IServiceCollection AddInfraServices(
            this IServiceCollection services
            /*IConfiguration configuration*/
        )
        {
            services.AddScoped<IProviderFactory, ProviderFactory>();

            return services;
        }
    }
}
