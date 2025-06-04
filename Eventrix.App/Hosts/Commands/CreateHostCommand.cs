using MediatR;

namespace Eventrix.App.Hosts.Commands
{
    public record CreateHostCommand(string Name, string Email, string? PhoneNumber = null, string? profilePictureurl = null, string? bio = null) : IRequest<Unit>;
}
