using Microsoft.Extensions.DependencyInjection;
using OC.Libraries.Interfaces;
using OC.Libraries.Security;

namespace OC.Libraries
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServices(
            this IServiceCollection services
            /*IConfiguration configuration*/
)
        {
            services.AddScoped<IEncryptData, EncryptData>();
            services.AddScoped<IDecryptData, DecryptData>();

            return services;
        }
    }
}
