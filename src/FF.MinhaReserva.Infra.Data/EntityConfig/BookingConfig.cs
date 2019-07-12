using FF.MinhaReserva.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FF.MinhaReserva.Infra.Data.EntityConfig
{
    public class BookingConfig : EntityTypeConfiguration<Booking>
    {
        public BookingConfig()
        {
            HasKey(b => b.Id);

            Property(b => b.BookingDate)
                .IsRequired();

            Property(b => b.StartDate)
                .IsRequired();

            Property(b => b.EndtDate)
                .IsRequired();

            Property(b => b.Comment)
                .HasMaxLength(200);

            Property(b => b.Status)
                .IsRequired();

            Property(b => b.IsDeleted)
               .IsRequired();


        }
    }
}
