using FF.MinhaReserva.Domain.Models;
using FF.MinhaReserva.Infra.Data.EntityConfig;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace FF.MinhaReserva.Infra.Data.Context
{
    public class MinhaReservaContext : DbContext
    {
        //Will always get the connection from start up project
        public MinhaReservaContext() : base("DefaultConnection")
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
            Configuration.AutoDetectChangesEnabled = false;
        }

        public DbSet<Attendee> Atendees { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Resource> Resources { get; set; }
        public DbSet<Booking> Bookings { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));

            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(100));

            modelBuilder.Ignore<ValidationResult>();


            //Fluent API
            modelBuilder.Configurations.Add(new AttendeeConfig());
            modelBuilder.Configurations.Add(new ResourceConfig());
            modelBuilder.Configurations.Add(new RoomConfig());
            modelBuilder.Configurations.Add(new BookingConfig());

            base.OnModelCreating(modelBuilder);
        }
    }
}
