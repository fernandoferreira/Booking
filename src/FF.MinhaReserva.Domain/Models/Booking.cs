using System;

namespace FF.MinhaReserva.Domain.Models
{
    public class Booking : Entity
    {
        public Guid RoomId { get; set; }
        public Guid AttendeeId { get; set; }
        public DateTime BookingDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndtDate { get; set; }
        //Frequency
        public string Comment { get; set; }
        public int Status { get; set; }
        //0- Avaliable 1-Booked 2-Cancelled

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
            return true;
        }
    }
}
