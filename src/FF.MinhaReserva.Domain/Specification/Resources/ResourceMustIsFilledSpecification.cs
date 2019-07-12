using DomainValidation.Interfaces.Specification;
using FF.MinhaReserva.Domain.Models;

namespace FF.MinhaReserva.Domain.Specification.Resources
{
    public class ResourceMustIsFilledSpecification : ISpecification<Resource>
    {
        public bool IsSatisfiedBy(Resource resource)
        {
            return resource.Description.Length >= 5 && resource.BrandId != null && resource.ModelId != null;
        }
    }
}
