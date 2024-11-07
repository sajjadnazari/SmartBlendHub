using Microsoft.Extensions.DependencyInjection;
using SmartBlendHub.Application.Common.Interfaces.Authentication;
using SmartBlendHub.Infrastructure.Authentication;

namespace SmartBlendHub.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
            return services;
        }
    }
}
