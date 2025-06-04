namespace Eventrix.App.Services
{
    public interface IRedisService
    {
        Task SetCodeAsync(string email, string code, TimeSpan expiry);
        Task<string?> GetCodeAsync(string email);
        Task DeleteCodeAsync(string email);
    }
}
