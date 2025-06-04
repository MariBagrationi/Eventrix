using Eventrix.App.Repositories;
using Eventrix.Domain.Models;
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

            //search gmail in the database and get the subscriber if already exists
            var subscriber = await _subscriberRepository.GetSubscriberByEmailAsync(request.Email, cancellationToken);
            if (subscriber == null)
            {
                //verify the gmail address and save the subscriber
                bool GmailVerified = true;
                if (!GmailVerified)
                {
                    throw new ArgumentException("Gmail verification failed.");
                }
              
                await _subscriberRepository.SaveSubscriberAsync(request.Name, request.Email, DateTime.UtcNow, cancellationToken);
                subscriber = await _subscriberRepository.GetSubscriberByEmailAsync(request.Email, cancellationToken);
            }
           
            var subscription = new HostSubscriber
            {
                HostId = request.HostId,
                SubscriberId = subscriber!.Id,
                SubscribedAt = DateTime.UtcNow
            };

            subscriber.SubscribedHosts.Add(subscription);
            await _subscriberRepository.UpdateSubscriberAsync(subscriber, cancellationToken);

            return Unit.Value;
        }
    }
}
