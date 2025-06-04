using Eventrix.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Eventrix.Persistence.Configurations
{
    public class HostSubscriberConfig : IEntityTypeConfiguration<HostSubscriber>
    {
        public void Configure(EntityTypeBuilder<HostSubscriber> builder)
        {
            //builder.HasKey(x => x.Id);

            builder.HasKey(x => new { x.HostId, x.SubscriberId });

            builder.Property(x => x.SubscribedAt);

            builder
                .HasOne(x => x.Host)
                .WithMany(h => h.Subscribers)
                .HasForeignKey(x => x.HostId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Subscriber)
                .WithMany(s => s.SubscribedHosts)
                .HasForeignKey(x => x.SubscriberId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
