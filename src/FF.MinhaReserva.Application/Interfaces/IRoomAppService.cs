using System;
using System.Collections.Generic;
using FF.MinhaReserva.Application.ViewModels;

namespace FF.MinhaReserva.Application.Services
{
    public interface IRoomAppService : IDisposable
    {
        IEnumerable<RoomViewModel> GetAll();

        RoomViewModel GetById(Guid id);

        RoomViewModel GetByName(string name);

        RoomViewModel Add(RoomViewModel roomViewModel);

        RoomViewModel Update(RoomViewModel roomViewModel);

        void Delete(Guid id);

    }
}
