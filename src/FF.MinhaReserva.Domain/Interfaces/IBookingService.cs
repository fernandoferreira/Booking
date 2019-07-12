using FF.MinhaReserva.Domain.Models;
using System;

namespace FF.MinhaReserva.Domain.Interfaces
{
    public interface IBookingService : IDisposable
    {
        Booking AddNewBooking(Booking booking);
        Booking UpdateBooking(Booking booking);
        void DeleteBooking(Guid id);
    }
}
