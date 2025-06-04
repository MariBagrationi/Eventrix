using MediatR;

namespace Eventrix.App.Subscribers.Commands
{
    public record SubscribeToHostCommand(
        string Name,
        string Email,
        int HostId) : IRequest<Unit>;
}
