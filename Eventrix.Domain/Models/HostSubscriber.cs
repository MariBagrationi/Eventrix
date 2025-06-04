
namespace Eventrix.Domain.Models
{
    public class HostSubscriber
    {
        public int Id { get; set; }
        public int HostId { get; set; }
        public Host Host { get; set; } = new Host();

        public int SubscriberId { get; set; }
        public Subscriber Subscriber { get; set; } = new Subscriber();
        public DateTime SubscribedAt { get; set; } = DateTime.UtcNow;
    }
}
