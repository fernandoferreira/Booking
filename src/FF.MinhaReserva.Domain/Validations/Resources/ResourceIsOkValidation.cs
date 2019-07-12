using DomainValidation.Validation;
using FF.MinhaReserva.Domain.Models;
using FF.MinhaReserva.Domain.Specification.Resources;

namespace FF.MinhaReserva.Domain.Validations.Resources
{
    public class ResourceIsOkValidation : Validator<Resource>
    {
        public ResourceIsOkValidation()
        {
            var resource = new ResourceMustIsFilledSpecification();
            base.Add("ToFill", new Rule<Resource>(resource, "Todos os campos devem estar preenchidos. Verifique."));
        }
    }
}
