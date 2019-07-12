using System;
using System.Collections.Generic;
using System.Linq;
using FF.MinhaReserva.Domain.Interfaces;
using FF.MinhaReserva.Domain.Models;
using FF.MinhaReserva.Infra.Data.Context;

namespace FF.MinhaReserva.Infra.Data.Repository
{
    public class AttendeeRepository : Repository<Attendee>, IAttendeeRepository
    {
        public AttendeeRepository(MinhaReservaContext context) : base(context){}

        public IEnumerable<Attendee> GetAllActive()
        {
            return SearchBy(a => !a.IsDeleted);
        }

        public Attendee GetByEmail(string email)
        {
            return SearchBy(a => a.Email == email && !a.IsDeleted).FirstOrDefault();
        }

        public Attendee GetByName(string name)
        {
            return SearchBy(a => a.Name == name && !a.IsDeleted).FirstOrDefault();
        }

        public override void Remove(Guid id)
        {
            var atendee = GetById(id);
            atendee.Delete();
            Update(atendee);
        }
    }
}
