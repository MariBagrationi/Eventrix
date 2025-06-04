namespace Eventrix.Domain.Models
{
    public class Subscriber
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public ICollection<HostSubscriber> SubscribedHosts { get; set; } = new List<HostSubscriber>();
    }
}
