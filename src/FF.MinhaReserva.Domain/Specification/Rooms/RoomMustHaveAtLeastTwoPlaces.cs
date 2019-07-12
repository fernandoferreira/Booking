using DomainValidation.Interfaces.Specification;
using FF.MinhaReserva.Domain.Models;

namespace FF.MinhaReserva.Domain.Specification.Rooms
{
    public class RoomMustHaveAtLeastTwoPlaces : ISpecification<Room>
    {
        public bool IsSatisfiedBy(Room room)
        {
            return room.NumberOfAtendees >= 2 ? true : false;
        }
    }
}
