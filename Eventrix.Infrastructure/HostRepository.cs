using Eventrix.App.Repositories;
using Eventrix.Domain.Models;
using Eventrix.Persistence.Context;

namespace Eventrix.Infrastructure
{
    public class HostRepository : BaseRepository<Host>, IHostRepository
    {
        public HostRepository(EventrixContext context) : base(context)
        {
        }

        public async Task CreateHostAsync(string name, string email, string? phone, string? profilePicUrl, string? bio, CancellationToken cancellationToken = default)
        {
            var entity = new Host
            {
                Name = name,
                Email = email,
                PhoneNumber = phone,
                ProfilePictureUrl = profilePicUrl,
                Bio = bio
            };

            await base.AddAsync(entity, cancellationToken);
        }

        public async Task DeleteHostAsync(int id, CancellationToken cancellationToken = default)
        {
            await base.DeleteByIdAsync(id, cancellationToken);
        }

        public async Task<Host?> GetHostByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await base.GetByIdAsync(id, cancellationToken);
        }
    }
}
