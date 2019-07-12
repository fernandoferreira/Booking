using System;
using FF.MinhaReserva.Domain.Models;

namespace FF.MinhaReserva.Domain.Interfaces
{
    public interface IResourceService : IDisposable
    {
        Resource Add(Resource resource);

        Resource Update(Resource resource);

        void Delete(Guid id);

    }
}
