using Eventrix.App.Subscribers.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Eventrix.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscribeController : ControllerBase
    {
        private readonly ILogger<SubscribeController> _logger;
        private readonly IMediator _mediator;
        public SubscribeController(ILogger<SubscribeController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpPost("/subscribe")]
        public async Task<IActionResult> SubscribeToEvent([FromBody] SubscribeToHostCommand subscribeCommand, CancellationToken cancellationToken)
        {
            if (subscribeCommand == null)
            {
                return BadRequest("Subscription details cannot be null.");
            }
            await _mediator.Send(subscribeCommand, cancellationToken);
            return Ok(new { Message = "Subscribed to event successfully", SubscriptionDetails = subscribeCommand });
        }
    }
}
