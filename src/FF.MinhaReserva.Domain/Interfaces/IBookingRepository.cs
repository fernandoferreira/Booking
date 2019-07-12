using FF.MinhaReserva.Domain.Models;
using System;
using System.Collections.Generic;

namespace FF.MinhaReserva.Domain.Interfaces
{
    //Do all the routines that belongs to repositories and its own methods
    public interface IBookingRepository : IRepository<Booking>, IRepositoryWriter<Booking>
    {
        IEnumerable<Booking> GetByDate(DateTime startDate, DateTime endDate);
        IEnumerable<Booking> GetByStatus(DateTime startDate, DateTime endDate, int status);
        IEnumerable<Booking> GetByRoom(Guid room, int status);
        IEnumerable<Booking> GetByAttendee(Guid attendeeId);
    }
}
