using FF.MinhaReserva.Domain.Validations.Rooms;
using System.Collections.Generic;

namespace FF.MinhaReserva.Domain.Models
{
    public class Room : Entity
    {
        public Room()
        {
            Resources = new List<Resource>();
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public int NumberOfAtendees { get; set; }
        public virtual ICollection<Resource> Resources { get; set; }

        public override void Activate()
        {
            IsDeleted = false;
        }

        public void AddResource(Resource resource)
        {
            Resources.Add(resource);
        }

        public override void Delete()
        {
            IsDeleted = true;
        }

        public override bool IsValid()
        {
            validationResult = new RoomIsOkValidation().Validate(this);
            return validationResult.IsValid;
            
        }
    }
}
