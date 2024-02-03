using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OC.Entities;

namespace OC.Infra.Mappings
{
    public class UserTypeChannelMapping : IEntityTypeConfiguration<UserTypeChannel>
    {
        public void Configure(EntityTypeBuilder<UserTypeChannel> builder)
        {
            builder.ToTable("UserTypeChannel");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.UserId).IsRequired();
            builder.Property(c => c.TypeChannelId).IsRequired();

            builder.HasOne(c => c.User).WithMany(c => c.UserTypeChannel).HasForeignKey(c => c.UserId);
            builder.HasOne(c => c.TypeChannel).WithMany(c => c.UserTypeChannel).HasForeignKey(c => c.TypeChannelId);
        }
    }
}
