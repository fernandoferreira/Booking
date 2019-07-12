using FF.MinhaReserva.Application.ViewModels;
using System;
using System.Collections.Generic;

namespace FF.MinhaReserva.Application.Interfaces
{
    public interface IBookingAppService : IDisposable
    {
        BookingViewModel Add(BookingViewModel bookingViewModel);

        BookingViewModel Update(BookingViewModel bookingViewModel);

        BookingViewModel Cancel(BookingViewModel bookingViewModel);

        IEnumerable<BookingViewModel> GetByDate(DateTime startDate, DateTime endDate);

        IEnumerable<BookingViewModel> GetByRoom(Guid roomId);

        IEnumerable<BookingViewModel> GetByAttendee(Guid attendeeId);

        IEnumerable<BookingViewModel> GetBystatus(DateTime startDate, DateTime endDate, int StatusId);
    }
}
