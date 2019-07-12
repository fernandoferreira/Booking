using FF.MinhaReserva.Domain.Models;

namespace FF.MinhaReserva.Domain.Interfaces
{
    public interface IResourceRepository : IRepository<Resource>, IRepositoryWriter<Resource>
    {
        Resource GetByDescripion(string description);
        
    }
}
