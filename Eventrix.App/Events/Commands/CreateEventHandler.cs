using Eventrix.App.Repositories;
using MediatR;

namespace Eventrix.App.Events.Commands
{
    public class CreateEventHandler : IRequestHandler<CreateEventCommand, Unit>
    {
        private readonly IEventRepository _eventRepository;
        public CreateEventHandler(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }
        public async Task<Unit> Handle(CreateEventCommand request, CancellationToken cancellationToken)
        {
            await _eventRepository.CreateEventAsync(
                request.Title,
                request.HostId,
                request.Description,
                request.StartDate,
                request.EndDate,
                request.Location,
                request.ImageUrl,
                cancellationToken
            );

            return Unit.Value;
        }
    }
}
