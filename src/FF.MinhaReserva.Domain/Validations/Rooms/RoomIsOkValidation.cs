using DomainValidation.Validation;
using FF.MinhaReserva.Domain.Models;
using FF.MinhaReserva.Domain.Specification.Rooms;

namespace FF.MinhaReserva.Domain.Validations.Rooms
{
    public class RoomIsOkValidation:Validator<Room>
    {
        public RoomIsOkValidation()
        {
            var placesAvailable = new RoomMustHaveAtLeastTwoPlaces();

            base.Add("PlacesAvailable", new Rule<Room>(placesAvailable, "O local do evento deve ter capacidade de pelo menos duas pessoas."));
        }
    }
}
