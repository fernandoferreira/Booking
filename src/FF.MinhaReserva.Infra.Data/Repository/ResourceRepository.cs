using System;
using System.Collections.Generic;
using System.Linq;
using FF.MinhaReserva.Domain.Interfaces;
using FF.MinhaReserva.Domain.Models;
using FF.MinhaReserva.Infra.Data.Context;

namespace FF.MinhaReserva.Infra.Data.Repository
{
    public class ResourceRepository : Repository<Resource>, IResourceRepository
    {
        public ResourceRepository(MinhaReservaContext context) : base(context) { }

        public Resource GetByDescripion(string description)
        {
            return SearchBy(r => r.Description == description).FirstOrDefault();
        }

        public override void Remove(Guid id)
        {
            var resource = GetById(id);

            resource.Delete();
            Update(resource);
        }

        public override IEnumerable<Resource> GetAll()
        {
            return SearchBy(r => !r.IsDeleted);
        }
    }
}
