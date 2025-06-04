using Eventrix.App.Repositories;
using Eventrix.Domain.Models;
using Eventrix.Persistence.Context;

namespace Eventrix.Infrastructure
{
    public class EventRepository : BaseRepository<Event>, IEventRepository
    {
        public EventRepository(EventrixContext context) : base(context)
        {
        }

        public async Task CreateEventAsync(string title, int hostId, string description, DateTime startDate, DateTime endDate, string location, string? imageUrl = null, CancellationToken cancellationToken = default)
        {
            var entity = new Event
            {
                Title = title,
                HostId = hostId,
                Description = description,
                StartDate = startDate,
                EndDate = endDate,
                Location = location,
                ImageUrl = imageUrl
            };

            await base.AddAsync(entity, cancellationToken);
        }
    }
}
