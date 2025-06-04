using Eventrix.App.Services;
using MediatR;

namespace Eventrix.App.Subscribers.Commands
{
    public class VerifyByCodeHandler : IRequestHandler<VerifyByCodeCommand, Unit>
    {
        private readonly IRedisService _redisService;
        private readonly IEmailQueue _emailQueue;
        public VerifyByCodeHandler(IRedisService redisService)
        {
            _redisService = redisService;
        }

        public async Task<Unit> Handle(VerifyByCodeCommand request, CancellationToken cancellationToken)
        {
            await _redisService.SetCodeAsync(request.Email, request.Code, TimeSpan.FromSeconds(30));
            //await _emailQueue.EnqueueAsync(new EmailJob { Email = email, Code = code });
            return Unit.Value;
        }
    }
}
