using Microsoft.Extensions.DependencyInjection;
using SmartBlendHub.Application.Services.Authentication;

namespace SmartBlendHub.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection serviceDescriptors)
        {
            serviceDescriptors.AddScoped<IAuthenticationService, AuthenticationService>();
            return serviceDescriptors;
        }
    }
}
