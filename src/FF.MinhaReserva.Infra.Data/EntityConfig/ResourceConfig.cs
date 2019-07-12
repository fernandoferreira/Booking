using FF.MinhaReserva.Domain.Models;
using System.Data.Entity.ModelConfiguration;

namespace FF.MinhaReserva.Infra.Data.EntityConfig
{
    class ResourceConfig:EntityTypeConfiguration<Resource>
    {
        public ResourceConfig()
        {
            HasKey(r => r.Id);

            Property(r => r.IsDeleted)
                .IsRequired();

        }
    }
}
