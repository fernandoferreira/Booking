using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FF.MinhaReserva.Application.ViewModels
{
    public class ResourceViewModel
    {
        public ResourceViewModel()
        {
            Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Preencha o campo Descrição.")]
        [MaxLength(100, ErrorMessage = "Máximo de 100 caracteres")]
        [MinLength(5, ErrorMessage = "Mínimo de  caracteres")]
        [DisplayName("Descrição")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Preencha o campo Marca.")]
        [DisplayName("Marca")]
        public Guid BrandId { get; set; }

        [Required(ErrorMessage = "Preencha o campo Modelo.")]
        [DisplayName("Modelo")]
        public Guid ModelId { get; set; }

        [DisplayName("Ativo")]
        public bool IsActive { get; set; }

        [ScaffoldColumn(false)]
        public DomainValidation.Validation.ValidationResult ValidationResult { get; set; }

    }
}
