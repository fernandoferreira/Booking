using FF.MinhaReserva.Application.Interfaces;
using FF.MinhaReserva.Application.Services;
using FF.MinhaReserva.Domain.Interfaces;
using FF.MinhaReserva.Domain.Services;
using FF.MinhaReserva.Infra.Data.Context;
using FF.MinhaReserva.Infra.Data.Repository;
using FF.MinhaReserva.Infra.Data.UoW;
using SimpleInjector;

namespace FF.MinhaReserva.Infra.CrossCutting.IoC
{
    public class SimpleInjectorBootStrapper
    {
        public static void Register(Container container)
        {

            //Applications
            container.Register<IRoomAppService, RoomAppService>(Lifestyle.Scoped);
            container.Register<IAttendeeAppService, AttendeeAppService>(Lifestyle.Scoped);
            container.Register<IResourceAppService, ResourceAppService>(Lifestyle.Scoped);
            container.Register<IBookingAppService, BookingAppService>(Lifestyle.Scoped);

            //Domain
            container.Register<IRoomService, RoomService>(Lifestyle.Scoped);
            container.Register<IAttendeeService, AttendeeService>(Lifestyle.Scoped);
            container.Register<IResourceService, ResourceService>(Lifestyle.Scoped);
            container.Register<IBookingService, BookingService>(Lifestyle.Scoped);

            //Data
            container.Register<IRoomRepository, RoomRepository>(Lifestyle.Scoped);
            container.Register<IAttendeeRepository, AttendeeRepository>(Lifestyle.Scoped);
            container.Register<IResourceRepository, ResourceRepository>(Lifestyle.Scoped);
            container.Register<IBookingRepository, BookingRepository>(Lifestyle.Scoped);
            container.Register<IUnitOfWork, UnitOfWork>(Lifestyle.Scoped);
            container.Register<MinhaReservaContext>(Lifestyle.Scoped);
        }
    }
}
