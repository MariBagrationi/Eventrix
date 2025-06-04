using MediatR;

namespace Eventrix.App.Events.Commands
{
    public record CreateEventCommand(string Title, int HostId, string Description, 
        DateTime StartDate, DateTime EndDate, string Location, string? ImageUrl = null) : IRequest<Unit>;
}
