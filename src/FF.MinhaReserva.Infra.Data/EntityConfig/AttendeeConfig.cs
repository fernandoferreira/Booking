using FF.MinhaReserva.Domain.Models;
using System.Data.Entity.ModelConfiguration;

namespace FF.MinhaReserva.Infra.Data.EntityConfig
{
    public class AttendeeConfig : EntityTypeConfiguration<Attendee>
    {
        public AttendeeConfig()
        {
            HasKey(a => a.Id);

            Property(a => a.Name)
                .IsRequired()
                .HasMaxLength(100);

            Property(a => a.Department)
                .IsRequired();

            Property(a => a.Email)
                .IsRequired();

            Property(a => a.IsDeleted)
                .IsRequired();

        }
    }
}
