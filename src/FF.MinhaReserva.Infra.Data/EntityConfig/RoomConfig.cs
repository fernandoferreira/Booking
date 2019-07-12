using FF.MinhaReserva.Domain.Models;
using System.Data.Entity.ModelConfiguration;

namespace FF.MinhaReserva.Infra.Data.EntityConfig
{
    class RoomConfig : EntityTypeConfiguration<Room>
    {
        public RoomConfig()
        {
            HasKey(r => r.Id);

            Property(r => r.Name)
                .IsRequired()
                .HasMaxLength(100);

            Property(r => r.Description)
                .HasMaxLength(150);

            Property(r => r.NumberOfAtendees)
                .IsRequired();

        }
    }
}
