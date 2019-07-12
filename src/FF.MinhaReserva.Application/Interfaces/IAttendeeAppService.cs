using System;
using System.Collections.Generic;
using FF.MinhaReserva.Application.ViewModels;

namespace FF.MinhaReserva.Application.Services
{
    //Just what the presentation layer can do (can ask domain).
    public interface IAttendeeAppService : IDisposable
    {
        AttendeeViewModel Add(AttendeeViewModel atendeeViewModel);

        AttendeeViewModel GetById(Guid id);

        AttendeeViewModel Update(AttendeeViewModel atendeeViewModel);

        IEnumerable<AttendeeViewModel> GetAllActive();

        AttendeeViewModel GetByName(string name);

        AttendeeViewModel GetByEmail(string email);

        void Delete(Guid id);
    }
}
