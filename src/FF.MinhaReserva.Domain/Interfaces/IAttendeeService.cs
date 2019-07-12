using System;
using FF.MinhaReserva.Domain.Models;

namespace FF.MinhaReserva.Domain.Interfaces
{
   public interface IAttendeeService:IDisposable
    {
        Attendee Add(Attendee atendee);

        Attendee Update(Attendee atendee);

        void Delete(Guid id);
    }
}
