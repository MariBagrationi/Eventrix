using Eventrix.App.Repositories;
using MediatR;

namespace Eventrix.App.Hosts.Commands
{
    public class CreateHostHandler : IRequestHandler<CreateHostCommand, Unit>
    {
        private readonly IHostRepository _hostRepository;

        public CreateHostHandler(IHostRepository hostRepository)
        {
            _hostRepository = hostRepository;
        }

        public async Task<Unit> Handle(CreateHostCommand request, CancellationToken cancellationToken)
        {
            await _hostRepository.CreateHostAsync(
                request.Name,
                request.Email,
                request.PhoneNumber,
                request.profilePictureurl,
                request.bio,
                cancellationToken
            );

            return Unit.Value;
        }
    }
}
