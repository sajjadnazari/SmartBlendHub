using SmartBlendHub.Application.Common.Interfaces.Services;

namespace SmartBlendHub.Infrastructure.Services
{
    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTime UtcNow => DateTime.UtcNow;
    }
}
