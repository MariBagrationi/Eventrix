using Eventrix.Domain.Models;

namespace Eventrix.App.Repositories
{
    public interface ISubscriberRepository
    {
        Task<bool> AlreadyExistsAsync(string gmail, CancellationToken cancellationToken = default);
        Task<Subscriber> GetSubscriberByEmailAsync(string gmail, CancellationToken cancellationToken = default);
        Task SaveSubscriberAsync(string name, string email, DateTime SubscribedAt, CancellationToken cancellationToken = default);     
        Task DeleteSubscriberAsync(int id, CancellationToken cancellationToken = default);
        Task UpdateSubscriberAsync(Subscriber subscriber, CancellationToken cancellationToken);
    }
}
