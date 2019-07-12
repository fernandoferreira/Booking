using FF.MinhaReserva.Domain.Models;
using System.Collections.Generic;

namespace FF.MinhaReserva.Domain.Interfaces
{
    public interface IAttendeeRepository : IRepository<Attendee>, IRepositoryWriter<Attendee>
    {
        Attendee GetByName(string name);
        Attendee GetByEmail(string email);
        IEnumerable<Attendee> GetAllActive();
    }
}
