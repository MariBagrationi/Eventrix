using Eventrix.App.Repositories;
using MediatR;

namespace Eventrix.App.Subscribers.Commands
{
    public class SubscribeToHostHandler : IRequestHandler<SubscribeToHostCommand, Unit>
    {
        private readonly ISubscriberRepository _subscriberRepository;
        private readonly IHostRepository _hostRepository;
        public SubscribeToHostHandler(ISubscriberRepository subscriberRepository, IHostRepository hostRepository)
        {
            _subscriberRepository = subscriberRepository;
            _hostRepository = hostRepository;
        }
        public async Task<Unit> Handle(SubscribeToHostCommand request, CancellationToken cancellationToken)
        {
            var host = await _hostRepository.GetHostByIdAsync(request.HostId, cancellationToken);
            if (host == null)
            {
                throw new ArgumentException($"Host with ID {request.HostId} does not exist.");
            }

            bool GmailVerified = true;
            await Task.Delay(1000, cancellationToken); // Simulate a delay for verification


            if (GmailVerified)
            {
                bool alreadyExists = await _subscriberRepository.AlreadyExistsAsync(request.Email, cancellationToken);
                if (!alreadyExists)
                {
                    await _subscriberRepository.SaveSubscriberAsync(
                        request.Name,
                        request.Email,
                        request.SubscribedAt,
                        cancellationToken
                    );
                }

                var subscriber = await _subscriberRepository.GetSubscriberByEmailAsync(request.Email, cancellationToken);
                subscriber.SubscribedHosts.Add(host!);
                await _subscriberRepository.UpdateSubscriberAsync(subscriber, cancellationToken);
            }
            else
            {
                throw new ArgumentException("Gmail verification failed.");
            }

            return Unit.Value;
        }
    }
}
