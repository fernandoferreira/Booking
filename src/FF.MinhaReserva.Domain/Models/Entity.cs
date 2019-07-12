using System;
using DomainValidation.Validation;

namespace FF.MinhaReserva.Domain.Models
{
    public abstract class Entity
    {
        public Guid Id { get; set; }
        public bool IsDeleted { get; set; }
        public ValidationResult validationResult { get; set; }

        public Entity()
        {
            Id = Guid.NewGuid();
        }

        public abstract bool IsValid();
        public abstract void Activate();
        public abstract void Delete();

        public void AddValidationError(string error)
        {
            validationResult.Add(new ValidationError(error));
        }
    }
}
