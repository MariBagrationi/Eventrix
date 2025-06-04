namespace Eventrix.Domain.Models
{
    public class Host
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string? PhoneNumber { get; set; } = string.Empty;
        public string? Bio { get; set; }
        public string? ProfilePictureUrl { get; set; }
        public ICollection<Event> Events { get; set; } = new List<Event>();
        public ICollection<HostSubscriber> Subscribers { get; set; } = new List<HostSubscriber>();
    }
}
