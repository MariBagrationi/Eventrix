using Eventrix.App.Repositories;
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
        }
    }
}
