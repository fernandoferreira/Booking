using AutoMapper;
using FF.MinhaReserva.Application.ViewModels;
using FF.MinhaReserva.Domain.Interfaces;
using FF.MinhaReserva.Domain.Models;
using FF.MinhaReserva.Infra.Data.UoW;
using System;
using System.Collections.Generic;

namespace FF.MinhaReserva.Application.Services
{
    public class AttendeeAppService : AppService, IAttendeeAppService
    {
        private readonly IAttendeeRepository _atendeeRepository;
        private readonly IAttendeeService _atendeeService;

        public AttendeeAppService(IAttendeeRepository atendeeRepository, IAttendeeService atendeeService, IUnitOfWork uow) : base(uow)
        {
            _atendeeRepository = atendeeRepository;
            _atendeeService = atendeeService;
        }

        public AttendeeViewModel GetByEmail(string email)
        {
            return Mapper.Map<AttendeeViewModel>(_atendeeRepository.GetByEmail(email));
        }

        public AttendeeViewModel GetById(Guid id)
        {
            return Mapper.Map<AttendeeViewModel>(_atendeeRepository.GetById(id));
        }

        public AttendeeViewModel GetByName(string name)
        {
            return Mapper.Map<AttendeeViewModel>(_atendeeRepository.GetByName(name));
        }

        public IEnumerable<AttendeeViewModel> GetAllActive()
        {
            return Mapper.Map<IEnumerable<AttendeeViewModel>>(_atendeeRepository.GetAllActive());
        }

        public AttendeeViewModel Add(AttendeeViewModel atendeeViewModel)
        {
            var atendee = Mapper.Map<Attendee>(atendeeViewModel);
            atendee.Activate();

            var atendeeRet = _atendeeService.Add(atendee);

            if (atendeeRet.validationResult.IsValid)
            {
                if (!Commit())
                {
                    //Either get an error or throw an error.
                }
            }

            atendeeViewModel = Mapper.Map<AttendeeViewModel>(atendeeRet);
            return atendeeViewModel;
        }

        public void Delete(Guid id)
        {
            _atendeeRepository.Remove(id);
        }

        public AttendeeViewModel Update(AttendeeViewModel atendeeViewModel)
        {
            var atendee = Mapper.Map<Attendee>(atendeeViewModel);

            //Must be improved
            if (atendee.IsValid())
                _atendeeRepository.Update(atendee);

            atendeeViewModel = Mapper.Map<AttendeeViewModel>(atendee);
            return atendeeViewModel;
        }

        public void Dispose()
        {
            _atendeeRepository.Dispose();
            _atendeeService.Dispose();
        }

    }
}
