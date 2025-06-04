using Eventrix.App.Repositories;
using Eventrix.App.Services;
using Eventrix.Infrastructure;

namespace Eventrix.API.Infrastructure.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IEventRepository, EventRepository>();
            services.AddScoped<ISubscriberRepository, SubscriberRepository>();
            services.AddScoped<IHostRepository, HostRepository>();
            services.AddScoped<IHostSubscriberRepository, HostSubscriberRepository>();

            services.AddSingleton<IRedisService, RedisService>();

        }
    }
}
