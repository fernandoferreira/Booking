using FF.MinhaReserva.Domain.Validations.Atendees;

namespace FF.MinhaReserva.Domain.Models
{
    public class Attendee : Entity
    {
        public string Name { get; set; }
        public int Department { get; set; }
        public string PhoneNumber { get; set; }
        public string Extension { get; set; }
        public string Email { get; set; }

        public override void Activate()
        {
            IsDeleted = false;
        }

        public override void Delete()
        {
            IsDeleted = true;
        }

        public override bool IsValid()
        {
            validationResult = new AttendeeIsOkValidation().Validate(this);
            return validationResult.IsValid;
        }
    }
}
