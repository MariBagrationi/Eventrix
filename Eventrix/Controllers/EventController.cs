using Eventrix.App.Events.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Eventrix.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly ILogger<EventController> _logger;
        private readonly IMediator _mediator;

        public EventController(ILogger<EventController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpPost("/events")]
        public async Task<IActionResult> HostEvent([FromBody] CreateEventCommand eventDetails, CancellationToken cancellationToken)
        {
            if (eventDetails == null)
            {
                return BadRequest("Event details cannot be null.");
            }
            await _mediator.Send(eventDetails, cancellationToken);
            return Ok(new { Message = "Event hosted successfully", EventDetails = eventDetails });
        }
    }
}
