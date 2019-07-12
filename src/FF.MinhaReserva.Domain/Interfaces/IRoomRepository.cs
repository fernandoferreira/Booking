using System.Collections.Generic;
using FF.MinhaReserva.Domain.Models;

namespace FF.MinhaReserva.Domain.Interfaces
{
    public interface IRoomRepository : IRepository<Room>, IRepositoryWriter<Room>
    {
        Room GetByName(string name);
        //IEnumerable<Room> GetAll();

    }
}
