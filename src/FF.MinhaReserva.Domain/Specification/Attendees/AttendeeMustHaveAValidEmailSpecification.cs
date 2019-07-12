using System;
using DomainValidation.Interfaces.Specification;
using FF.MinhaReserva.Domain.Models;
using FF.MinhaReserva.Domain.ValueObject;

namespace FF.MinhaReserva.Domain.Specification.Atendees
{
    public class AttendeeMustHaveAValidEmailSpecification : ISpecification<Attendee>
    {
        public bool IsSatisfiedBy(Attendee atendee)
        {
            return EmailAdress.Validate(atendee.Email);
        }
    }
}
