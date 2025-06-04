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

        [HttpPost("/verify")]
        public async Task<IActionResult> VerifyEmail([FromBody] string email, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(email))
            {
                return BadRequest("Email cannot be null or empty.");
            }

            var code = new Random().Next(100000, 999999).ToString();
            await _mediator.Send(new VerifyByCodeCommand(email, code), cancellationToken);
            return Ok(new { Message = "Verification code sent", Code = code });
        }


        [HttpPost("/subscribe")]
        public async Task<IActionResult> SubscribeToHost([FromBody] SubscribeToHostCommand subscribeCommand, CancellationToken cancellationToken)
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
