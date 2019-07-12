using System;
using System.Collections.Generic;
using FF.MinhaReserva.Domain.Interfaces;
using FF.MinhaReserva.Domain.Models;
using FF.MinhaReserva.Infra.Data.Context;

namespace FF.MinhaReserva.Infra.Data.Repository
{
    public class BookingRepository : Repository<Booking>, IBookingRepository
    {
        public BookingRepository(MinhaReservaContext context) : base(context) { }

        public IEnumerable<Booking> GetByAttendee(Guid attendeeId)
        {
            return SearchBy(b => b.AttendeeId == attendeeId && b.IsDeleted == false);
        }

        public IEnumerable<Booking> GetByDate(DateTime startDate, DateTime endDate)
        {
            return SearchBy(b => b.StartDate >= startDate && b.EndtDate <= endDate);
        }

        public IEnumerable<Booking> GetByRoom(Room room, int status)
        {
            return SearchBy(b => b.RoomId == room.Id && b.Status == status);
        }

        public IEnumerable<Booking> GetByRoom(Guid roomId)
        {
            return SearchBy(b => b.RoomId == roomId);
        }

        public IEnumerable<Booking> GetByRoom(Guid room, int status)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Booking> GetByStatus(DateTime startDate, DateTime endDate, int status)
        {
            return SearchBy((b => b.StartDate >= startDate && b.EndtDate <= endDate && b.Status == status));
        }
    }
}
