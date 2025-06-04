using Eventrix.App.Services;
using Microsoft.Extensions.Configuration;
using StackExchange.Redis;
using System.Text.Json;

namespace Eventrix.Infrastructure
{
    public class RedisEmailQueue : IEmailQueue
    {
        private readonly IDatabase _db;

        public RedisEmailQueue(IConfiguration config)
        {
            var redis = ConnectionMultiplexer.Connect(config["Redis:ConnectionString"]!);
            _db = redis.GetDatabase();
        }

        public async Task EnqueueAsync(EmailJob job)
        {
            var serialized = JsonSerializer.Serialize(job);
            await _db.ListRightPushAsync("email-queue", serialized);
        }

        public async Task<EmailJob?> DequeueAsync(CancellationToken token)
        {
            var value = await _db.ListLeftPopAsync("email-queue");
            return value.HasValue ? JsonSerializer.Deserialize<EmailJob>(value!) : null;
        }
    }

}
