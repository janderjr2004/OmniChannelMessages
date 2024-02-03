using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OC.Entities;

namespace OC.Infra.Mappings
{
    public class UserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            builder.HasKey(c => c.Id);

            builder.HasIndex(c => c.Login).IsUnique();

            builder.Property(c => c.Login).IsRequired().HasMaxLength(20);
            builder.Property(c => c.Password).IsRequired();
        }
    }
}
