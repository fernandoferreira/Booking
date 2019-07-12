using AutoMapper;
using FF.MinhaReserva.Application.ViewModels;
using FF.MinhaReserva.Domain.Models;

namespace FF.MinhaReserva.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Attendee, AttendeeViewModel>().ReverseMap();
            CreateMap<Resource, ResourceViewModel>().ReverseMap();
            CreateMap<Room, RoomViewModel>().ReverseMap();
            CreateMap<Booking, BookingViewModel>().ReverseMap();
        }
    }
}
