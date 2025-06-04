using Eventrix.App.Services;
using Eventrix.Infrastructure;
using StackExchange.Redis;

namespace Eventrix.WorkerService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = Host.CreateApplicationBuilder(args);

            builder.Services.AddSingleton<IEmailQueue, RedisEmailQueue>();
            builder.Services.AddHostedService<EmailWorker>();
            builder.Services.AddTransient<IEmailSender, EmailSender>();

            builder.Services.AddSingleton<IConnectionMultiplexer>(
                    ConnectionMultiplexer.Connect(builder.Configuration["Redis:ConnectionString"]!));

            var host = builder.Build();
            host.Run();
        }
    }
}