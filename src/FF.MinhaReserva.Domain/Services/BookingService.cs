using FF.MinhaReserva.Domain.Interfaces;
using FF.MinhaReserva.Domain.Models;
using System;

namespace FF.MinhaReserva.Domain.Services
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _bookingRepository;

        public BookingService(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }

        public Booking AddNewBooking(Booking booking)
        {
            if (!booking.IsValid())
                return booking;

            return _bookingRepository.Add(booking);
        }

        public void DeleteBooking(Guid id)
        {
            _bookingRepository.Remove(id);
        }

        public Booking UpdateBooking(Booking booking)
        {
            if (!booking.IsValid())
                return booking;

            return _bookingRepository.Update(booking);
        }

        public void Dispose()
        {
            _bookingRepository.Dispose();
        }
    }
}
