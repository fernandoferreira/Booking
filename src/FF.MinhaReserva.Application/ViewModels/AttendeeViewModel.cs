using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FF.MinhaReserva.Application.ViewModels
{
    public class AttendeeViewModel
    {
        //Opcional, pois já existe na entidade de domínio.
        public AttendeeViewModel()
        {
            Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Preencha o campo nome.")]
        [MaxLength(100, ErrorMessage = "Máximo de 100 caracteres")]
        [MinLength(5, ErrorMessage = "Mínimo de 5 caracteres")]
        [DisplayName("Nome")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Preencha o campo Setor.")]
        [DisplayName("Setor:")]
        public int Department { get; set; }

        [Required(ErrorMessage = "Preencha o campo Telefone.")]
        [DisplayName("Telefone:")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Preencha o campo Ramal.")]
        [DisplayName("Ramal:")]
        public string Extension { get; set; }

        [Required(ErrorMessage = "Preencha o campo E-Mail.")]
        [MaxLength(150, ErrorMessage = "Máximo de 150 caracteres")]
        [EmailAddress(ErrorMessage = "Preencha um e-mail válido")]
        [DisplayName("E-Mail:")]
        public string Email { get; set; }

        [DisplayName("Ativo")]
        public bool IsActive { get; set; }

        [ScaffoldColumn(false)]
        public DomainValidation.Validation.ValidationResult ValidationResult { get; set; }

    }
}
