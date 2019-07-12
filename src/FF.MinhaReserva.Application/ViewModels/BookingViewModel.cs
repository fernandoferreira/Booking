using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FF.MinhaReserva.Application.ViewModels
{
    public class BookingViewModel
    {
        public BookingViewModel()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; private set; }

        [DisplayName("Sala/Local")]
        [Required(ErrorMessage = "Preencha o campo Sala/Local.")]
        public Guid RoomId { get; set; }

        [DisplayName("Solicitante")]
        [Required(ErrorMessage = "Preencha o campo solicitante da reserva.")]
        public Guid AttendeeId { get; set; }

        [DisplayName("Data da reserva")]
        [Required(ErrorMessage = "Preencha o campo Data da reserva.")]
        public DateTime BookingDate { get; set; }

        [DisplayName("Início do evento")]
        [Required(ErrorMessage = "Preencha o campo Início do evento.")]
        public DateTime StartDate { get; set; }


        [DisplayName("Fim do evento")]
        [Required(ErrorMessage = "Preencha o campo Fim do evento.")]
        public DateTime EndtDate { get; set; }

        //Frequency
        [DisplayName("Observações")]
        public string Comment { get; set; }

        public int Status { get; set; }

        [ScaffoldColumn(false)]
        public DomainValidation.Validation.ValidationResult ValidationResult { get; set; }

    }
}
