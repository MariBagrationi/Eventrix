using Eventrix.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Eventrix.Persistence.Configurations
{
    public class EventConfiguration : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Title)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(e => e.Description)
                .IsRequired()
                .HasMaxLength(500)
                .IsUnicode(false); // Store as non-Unicode to save space

            builder.Property(e => e.StartDate);
            builder.Property(e => e.EndDate);
            builder.Property(e => e.Location)
                .IsRequired()
                .HasMaxLength(200)
                .IsUnicode(false); // Store as non-Unicode to save space

            builder.Property(e => e.ImageUrl);
            builder.Property(e => e.IsCancelled)
                .HasDefaultValue(false);

        }
    }
}
