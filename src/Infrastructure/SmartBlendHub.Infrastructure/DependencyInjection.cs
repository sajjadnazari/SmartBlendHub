using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SmartBlendHub.Application.Common.Interfaces.Authentication;
using SmartBlendHub.Application.Common.Interfaces.Services;
using SmartBlendHub.Infrastructure.Authentication;
using SmartBlendHub.Infrastructure.Services;

namespace SmartBlendHub.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, ConfigurationManager configurationManager)
        {
            services.Configure<JwtSetting>(configurationManager.GetSection(JwtSetting.SectionName));

            services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
            services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
            return services;
        }
    }
}
