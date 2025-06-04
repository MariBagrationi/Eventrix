using Eventrix.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Eventrix.Persistence.Context
{
    public class EventrixContext : DbContext
    {
        public EventrixContext(DbContextOptions<EventrixContext> options) : base(options)
        {
        }

        public DbSet<Subscriber> Subscribers { get; set; }
        public DbSet<Host> Hosts { get; set; }
        public DbSet<HostSubscriber> HostSubscribers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(EventrixContext).Assembly);
        }
    }
}
