using System;
using FF.MinhaReserva.Domain.Interfaces;
using FF.MinhaReserva.Domain.Models;

namespace FF.MinhaReserva.Domain.Services
{
    public class AttendeeService : IAttendeeService
    {
        public readonly IAttendeeRepository _atendeeRepository;

        public AttendeeService(IAttendeeRepository atendeeRepository)
        {
            _atendeeRepository = atendeeRepository;
        }

        public Attendee Add(Attendee atendee)
        {
            if (!atendee.IsValid())
                return atendee;

            return _atendeeRepository.Add(atendee);
        }

        public void Delete(Guid id)
        {
            _atendeeRepository.Remove(id);
        }

        public Attendee Update(Attendee atendee)
        {
            if (!atendee.IsValid())
                return atendee;

            return _atendeeRepository.Update(atendee);
        }

        public void Dispose()
        {
            _atendeeRepository.Dispose();
        }
    }
}
