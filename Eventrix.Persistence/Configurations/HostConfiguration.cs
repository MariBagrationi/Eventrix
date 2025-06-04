using Eventrix.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Eventrix.Persistence.Configurations
{
    public class HostConfiguration : IEntityTypeConfiguration<Host>
    {
        public void Configure(EntityTypeBuilder<Host> builder)
        {
            builder.HasKey(h => h.Id);
            builder.Property(h => h.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(h => h.Email).HasConversion(
                v => v,
                v => new System.Net.Mail.MailAddress(v).Address)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false); // Store as non-Unicode to save space

            builder.Property(h => h.PhoneNumber);

            builder.Property(h => h.Bio)
                .HasMaxLength(500)
                .IsUnicode(false); // Store as non-Unicode to save space
        }
    }
}
