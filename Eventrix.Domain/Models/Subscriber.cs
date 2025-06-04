namespace Eventrix.Domain.Models
{
    public class Subscriber
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateTime SubscribedAt { get; set; } = DateTime.UtcNow;

        // Navigation properties
        public ICollection<Host> SubscribedHosts { get; set; } = new List<Host>();
    }
}
