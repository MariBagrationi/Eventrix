namespace Eventrix.App.Repositories
{
    public interface IHostSubscriberRepository
    {
        /// <summary>
        /// Subscribes a user to a host.
        /// </summary>
        /// <param name="subscriberId">The ID of the subscriber.</param>
        /// <param name="hostId">The ID of the host.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task SubscribeAsync(int subscriberId, int hostId, CancellationToken cancellationToken);

        /// <summary>
        /// Unsubscribes a user from a host.
        /// </summary>
        /// <param name="subscriberId">The ID of the subscriber.</param>
        /// <param name="hostId">The ID of the host.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task UnsubscribeAsync(int subscriberId, int hostId, CancellationToken cancellationToken);
    }
}
