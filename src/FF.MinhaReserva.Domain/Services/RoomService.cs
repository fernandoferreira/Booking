using System;
using FF.MinhaReserva.Domain.Interfaces;
using FF.MinhaReserva.Domain.Models;

namespace FF.MinhaReserva.Domain.Services
{
   public class RoomService : IRoomService
    {
        private readonly IRoomRepository _roomRepository;

        public RoomService(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public Room Add(Room room)
        {
            if (!room.IsValid())
                return room;

            return _roomRepository.Add(room);
            //Validations here
        }

        public void Delete(Guid id)
        {
            //Is there any rule before delete?
            _roomRepository.Remove(id);
        }

        public Room Update(Room room)
        {
            if (!room.IsValid())
                return room;

            return _roomRepository.Update(room);
            //Validations here
        }

        public void Dispose()
        {
            _roomRepository.Dispose();
        }
    }
}
