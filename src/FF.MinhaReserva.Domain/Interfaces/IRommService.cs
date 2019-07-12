using System;
using FF.MinhaReserva.Domain.Models;

namespace FF.MinhaReserva.Domain.Interfaces
{
    public interface IRoomService : IDisposable
    {
        Room Add(Room room);

        Room Update(Room rom);

        void Delete(Guid id);
    }
}
