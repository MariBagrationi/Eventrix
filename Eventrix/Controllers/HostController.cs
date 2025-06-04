using Eventrix.App.Hosts.Commands;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Eventrix.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HostController : ControllerBase
    {
        private readonly ILogger<HostController> _logger;
        private readonly IMediator _mediator;
        public HostController(ILogger<HostController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpPost("/hosts")]
        public async Task<IActionResult> RegisterHost([FromBody] CreateHostCommand host, CancellationToken cancellationToken)
        {
            if (host == null)
            {
                return BadRequest("Host details cannot be null.");
            }
            await _mediator.Send(host, cancellationToken);
            return Ok(new { Message = "Host registered successfully", HostDetails = host });
        }
    }
}
