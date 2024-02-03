using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OC.Entities;

namespace OC.Infra.Mappings
{
    public class LogMessagesMapping : IEntityTypeConfiguration<LogMessage>
    {
        public void Configure(EntityTypeBuilder<LogMessage> builder)
        {
            builder.ToTable("LogMessages");
           
            builder.HasKey(c => c.Id);

            builder.Property(c => c.TypeChannelId).IsRequired();
            builder.Property(c => c.UserId).IsRequired();
            builder.Property(c => c.Message).IsRequired();
            builder.Property(c => c.Date).IsRequired();
            builder.Property(c => c.Referent).IsRequired();
            builder.Property(c => c.Recipient).IsRequired();

            builder.HasOne(c => c.User).WithMany(c => c.LogMessages).HasForeignKey(c => c.UserId);
            builder.HasOne(c => c.TypeChannel).WithMany(c => c.LogMessages).HasForeignKey(c => c.TypeChannelId);
        }
    }
}
