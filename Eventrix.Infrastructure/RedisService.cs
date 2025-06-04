using Eventrix.App.Services;
using Microsoft.Extensions.Configuration;
using StackExchange.Redis;

namespace Eventrix.Infrastructure
{
    public class RedisService : IRedisService
    {
        private readonly IDatabase _db;

        public RedisService(IConfiguration config)
        {
            var redis = ConnectionMultiplexer.Connect(config["Redis:ConnectionString"]);
            _db = redis.GetDatabase();
        }

        public Task SetCodeAsync(string email, string code, TimeSpan expiry)
            => _db.StringSetAsync($"verify:{email}", code, expiry);

        public async Task<string?> GetCodeAsync(string email)
        {
            var value = await _db.StringGetAsync($"verify:{email}");
            return value.HasValue ? value.ToString() : null;
        }

        public Task DeleteCodeAsync(string email)
            => _db.KeyDeleteAsync($"verify:{email}");
    }
}
