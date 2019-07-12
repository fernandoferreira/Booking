using FF.MinhaReserva.Domain.Validations.Resources;
using System;

namespace FF.MinhaReserva.Domain.Models
{
    public class Resource : Entity
    {
        public string Description { get; set; }
        public Guid BrandId { get; set; }
        public Guid ModelId { get; set; }


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
            validationResult = new ResourceIsOkValidation().Validate(this);
            return validationResult.IsValid;
        }
    }
}