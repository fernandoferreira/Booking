using AutoMapper;
using FF.MinhaReserva.Application.Interfaces;
using FF.MinhaReserva.Application.ViewModels;
using FF.MinhaReserva.Domain.Interfaces;
using FF.MinhaReserva.Domain.Models;
using FF.MinhaReserva.Infra.Data.UoW;
using System;
using System.Collections.Generic;

namespace FF.MinhaReserva.Application.Services
{
    /// <summary>
    /// //0- Avaliable 1-Booked 2-Cancelled
    /// </summary>
    public class BookingAppService : AppService, IBookingAppService
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly IBookingService _bookingService;

        public BookingAppService(IBookingRepository bookingRepository, IBookingService bookingService, IUnitOfWork uow) : base(uow)
        {
            _bookingRepository = bookingRepository;
            _bookingService = bookingService;
        }

        public BookingViewModel Add(BookingViewModel bookingViewModel)
        {
            var booking = Mapper.Map<Booking>(bookingViewModel);
            booking.Activate();

            var bookingRet = _bookingService.AddNewBooking(booking);

            if (bookingRet.validationResult.IsValid)
            {
                if (!Commit())
                {

                }
            }

            return bookingViewModel = Mapper.Map<BookingViewModel>(bookingRet);
        }

        public BookingViewModel Update(BookingViewModel bookingViewModel)
        {
            var booking = Mapper.Map<Booking>(bookingViewModel);
            if (booking.IsValid())
                _bookingRepository.Update(booking);

            return bookingViewModel = Mapper.Map<BookingViewModel>(booking);
        }

        public BookingViewModel Cancel(BookingViewModel bookingViewModel)
        {
            var booking = Mapper.Map<Booking>(bookingViewModel);
            booking.Status = 2;

            _bookingRepository.Update(booking);

            return bookingViewModel = Mapper.Map<BookingViewModel>(booking);
        }

        public IEnumerable<BookingViewModel> GetByAttendee(Guid bookingViewModel)
        {
            var booking = Mapper.Map<Booking>(bookingViewModel);
            return Mapper.Map<IEnumerable<BookingViewModel>>(_bookingRepository.GetByAttendee(booking.AttendeeId));
        }

        public IEnumerable<BookingViewModel> GetByDate(DateTime startDate, DateTime endDate)
        {
            return Mapper.Map<IEnumerable<BookingViewModel>>(_bookingRepository.GetByDate(startDate, endDate));
        }

        public IEnumerable<BookingViewModel> GetByRoom(Guid roomId)
        {
            return Mapper.Map<IEnumerable<BookingViewModel>>(_bookingRepository.GetByRoom(roomId, 1));
        }

        public IEnumerable<BookingViewModel> GetBystatus(DateTime startDate, DateTime endDate, int StatusId)
        {
            return Mapper.Map<IEnumerable<BookingViewModel>>(_bookingRepository.GetByStatus(startDate, endDate, StatusId));
        }

        public void Dispose()
        {
            _bookingRepository.Dispose();
            _bookingService.Dispose();
        }
    }
}
