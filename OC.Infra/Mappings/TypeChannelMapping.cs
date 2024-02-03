using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OC.Entities;

namespace OC.Infra.Mappings
{
    public class TypeChannelMapping : IEntityTypeConfiguration<TypeChannel>
    {
        public void Configure(EntityTypeBuilder<TypeChannel> builder)
        {
            builder.ToTable("TypeChannels");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name);
        }
    }
}
