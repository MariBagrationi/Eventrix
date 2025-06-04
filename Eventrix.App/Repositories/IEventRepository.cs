
namespace Eventrix.App.Repositories
{
    public interface IEventRepository
    {
        Task CreateEventAsync(string title, int hostId, string description, DateTime startDate, DateTime endDate, string location, string? imageUrl = null, CancellationToken cancellationToken = default);
    }
}
