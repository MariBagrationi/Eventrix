using Eventrix.Domain.Models;

namespace Eventrix.App.Repositories
{
    public interface IHostRepository
    {
        Task CreateHostAsync(string name, string email, string? phone, string? profilePicUrl, string? bio, CancellationToken cancellationToken = default);

        Task<Host?> GetHostByIdAsync(int id, CancellationToken cancellationToken = default);

        //Task<IEnumerable<Host>> GetAllHostsAsync(CancellationToken cancellationToken = default);

        //Task UpdateHostAsync(Host host, CancellationToken cancellationToken = default);

        Task DeleteHostAsync(int id, CancellationToken cancellationToken = default);
    }
}
