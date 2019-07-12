using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using FF.MinhaReserva.Domain.Models;

namespace FF.MinhaReserva.Application.ViewModels
{
    public class RoomViewModel
    {
        public RoomViewModel()
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

        [Required(ErrorMessage = "Preencha o campo Descrição.")]
        [MaxLength(150, ErrorMessage = "Máximo de 150 caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo de 2 caracteres")]
        [DisplayName("Descrição")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Preencha o campo capacidade.")]
        [DisplayName("Capacidade")]
        public int NumberOfAtendees { get; set; }

        [DisplayName("Ativo")]
        public bool IsActive { get; set; }


        public virtual ICollection<Resource> Resources { get; set; }

        [ScaffoldColumn(false)]
        public DomainValidation.Validation.ValidationResult ValidationResult { get; set; }

    }
}
