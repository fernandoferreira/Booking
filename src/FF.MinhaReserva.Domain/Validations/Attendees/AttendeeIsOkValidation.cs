using DomainValidation.Validation;
using FF.MinhaReserva.Domain.Models;
using FF.MinhaReserva.Domain.Specification.Atendees;

namespace FF.MinhaReserva.Domain.Validations.Atendees
{
    public class AttendeeIsOkValidation:Validator<Attendee>
    {
        public AttendeeIsOkValidation()
        {
            var emailAdress = new AttendeeMustHaveAValidEmailSpecification();

            base.Add("EmailAdressValidation", new Rule<Attendee>(emailAdress, "E-mail inválido."));
        }
    }
}
