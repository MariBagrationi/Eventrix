using MediatR;

namespace Eventrix.App.Subscribers.Commands
{
    public record VerifyByCodeCommand(string Email, string Code) : IRequest<Unit>;
}
