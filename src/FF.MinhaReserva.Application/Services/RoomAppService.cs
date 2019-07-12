using AutoMapper;
using FF.MinhaReserva.Application.ViewModels;
using FF.MinhaReserva.Domain.Interfaces;
using FF.MinhaReserva.Domain.Models;
using FF.MinhaReserva.Infra.Data.UoW;
using System;
using System.Collections.Generic;

namespace FF.MinhaReserva.Application.Services
{
    public class RoomAppService : AppService, IRoomAppService
    {
        protected readonly IRoomRepository _roomRepository;
        protected readonly IRoomService _roomService;

        public RoomAppService(IRoomRepository roomRepository, IRoomService roomService, IUnitOfWork uow) : base(uow)
        {
            _roomRepository = roomRepository;
            _roomService = roomService;
        }

        public RoomViewModel GetById(Guid id)
        {
            return Mapper.Map<RoomViewModel>(_roomRepository.GetById(id));
        }

        public IEnumerable<RoomViewModel> GetAll()
        {
            //throw new System.Exception("Primeira exception...");
            return Mapper.Map<IEnumerable<RoomViewModel>>(_roomRepository.GetAll());
        }

        public RoomViewModel GetByName(string name)
        {
            return Mapper.Map<RoomViewModel>(_roomRepository.GetByName(name));
        }

        public RoomViewModel Add(RoomViewModel roomViewModel)
        {
            var room = Mapper.Map<Room>(roomViewModel);
            room.Activate();

            //Must be improved.
            var roomRet = _roomService.Add(room);
            if (roomRet.validationResult.IsValid)
                if (!Commit()) { }

            roomViewModel = Mapper.Map<RoomViewModel>(roomRet);
            return roomViewModel;
        }

        public RoomViewModel Update(RoomViewModel roomViewModel)
        {
            var room = Mapper.Map<Room>(roomViewModel);

            //Must be improved.
            _roomService.Update(room);

            roomViewModel = Mapper.Map<RoomViewModel>(room);
            return roomViewModel;
        }

        public void Delete(Guid id)
        {
            _roomService.Delete(id);
        }

        public void Dispose()
        {
            _roomRepository.Dispose();
            _roomService.Dispose();
        }

    }
}
