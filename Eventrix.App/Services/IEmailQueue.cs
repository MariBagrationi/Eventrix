
namespace Eventrix.App.Services
{
    public interface IEmailQueue
    {
        Task EnqueueAsync(EmailJob job);
        Task<EmailJob?> DequeueAsync(CancellationToken token);
    }

}
