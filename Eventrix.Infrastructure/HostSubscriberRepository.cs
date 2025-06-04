using Eventrix.App.Repositories;
using Eventrix.Domain.Models;
using Eventrix.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Eventrix.Infrastructure
{
    public class HostSubscriberRepository : BaseRepository<HostSubscriber>, IHostSubscriberRepository
    {
        public HostSubscriberRepository(EventrixContext context) : base(context)
        {
        }

        public async Task SubscribeAsync(int subscriberId, int hostId, CancellationToken cancellationToken)
        {
            var subscription = new HostSubscriber
            {
                SubscriberId = subscriberId,
                HostId = hostId,
                SubscribedAt = DateTime.UtcNow
            };
            await base.AddAsync(subscription, cancellationToken);
        }

        public async Task UnsubscribeAsync(int subscriberId, int hostId, CancellationToken cancellationToken)
        {
            var subscriber = _dbSet
                .AsNoTracking()
                .FirstOrDefault(hs => hs.SubscriberId == subscriberId && hs.HostId == hostId);

            await base.DeleteAsync(subscriber!, cancellationToken);
        }
    }
}
