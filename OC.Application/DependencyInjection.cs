using Microsoft.Extensions.DependencyInjection;
using OC.Application.Interfaces.Commands;
using OC.Application.UseCases.AuthCases.Commands;
using OC.Application.UseCases.MessagesCases.Commands;
using OC.Application.UseCases.TypeChannelCases.Commands;
using OC.Application.UseCases.UserCases.Commands;

namespace OC.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(
            this IServiceCollection services
        )
        {
            services.AddScoped<ICreateUserCommand, CreateUserCommand>();
            services.AddScoped<ISendMessageCommand, SendMessageCommand>();
            services.AddScoped<ILinkUserTypeChannelCommand, LinkUserTypeChannelCommand>();
            services.AddScoped<IAuthCommand, AuthCommand>();

            return services;
        }
    }
}
