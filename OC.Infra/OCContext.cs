using Microsoft.EntityFrameworkCore;
using OC.Entities;

namespace OC.Infra
{
    public class OCContext : DbContext
    {
        public DbSet<LogMessage> LogMessages { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<TypeChannel> TypeChannels { get; set; }
        public DbSet<UserTypeChannel> UserTypeChannels { get; set; }

        public OCContext(DbContextOptions<OCContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(OCContext).Assembly);

            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                foreach (var navigation in entityType.GetNavigations())
                {
                    navigation.SetPropertyAccessMode(PropertyAccessMode.Field);
                    navigation.SetIsEagerLoaded(false);
                }
            }

            base.OnModelCreating(modelBuilder);

            InsertDefaultDatas(modelBuilder);
        }

        private static void InsertDefaultDatas(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TypeChannel>().HasData(
                new TypeChannel
                {
                    Id = 1,
                    Name = "Whatsapp"
                });

            modelBuilder.Entity<TypeChannel>().HasData(
                new TypeChannel
                {
                    Id = 2,
                    Name = "Email"
                });

            modelBuilder.Entity<TypeChannel>().HasData(
                new TypeChannel
                {
                    Id = 3,
                    Name = "SMS"
                });
        }
    }
}