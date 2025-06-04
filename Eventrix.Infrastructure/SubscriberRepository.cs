using Eventrix.App.Repositories;
using Eventrix.Domain.Models;
using Eventrix.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Eventrix.Infrastructure
{
    public class SubscriberRepository : BaseRepository<Subscriber>, ISubscriberRepository
    {
        public SubscriberRepository(EventrixContext context) : base(context)
        {
        }

        public Task<bool> AlreadyExistsAsync(string gmail, CancellationToken cancellationToken = default)
        {
            return _dbSet.AnyAsync(s => s.Email == gmail, cancellationToken);
        }

        public async Task DeleteSubscriberAsync(int id, CancellationToken cancellationToken = default)
        {
            await base.DeleteByIdAsync(id, cancellationToken);
        }

        public async Task<Subscriber?> GetSubscriberByEmailAsync(string gmail, CancellationToken cancellationToken = default)
        {
            return await _dbSet
                //.AsNoTracking()
                .FirstOrDefaultAsync(s => s.Email == gmail, cancellationToken);
        }

        public async Task SaveSubscriberAsync(string name, string email, DateTime SubscribedAt, CancellationToken cancellationToken = default)
        {
            await base.AddAsync(new Subscriber
            {
                Name = name,
                Email = email,
            }, cancellationToken);
        }

        public async Task UpdateSubscriberAsync(Subscriber subscriber, CancellationToken cancellationToken)
        {
            await base.UpdateAsync(subscriber, cancellationToken);
        }
    }
}
