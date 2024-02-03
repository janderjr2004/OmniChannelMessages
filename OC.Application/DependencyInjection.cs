using Microsoft.Extensions.DependencyInjection;
using OC.Application.Interfaces.Commands;
using OC.Application.UseCases.TypeChannelCases.Commands;
using OC.Application.UseCases.UserCases.Commands;

namespace OC.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(
            this IServiceCollection services
                /*IConfiguration configuration*/
        )
        {
            services.AddScoped<ICreateUserCommand, CreateUserCommand>();
            services.AddScoped<ILinkUserTypeChannelCommand, LinkUserTypeChannelCommand>();

            return services;
        }
    }
}
