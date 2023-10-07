using HappyPaws.API.Core.Enums;

namespace HappyPaws.API.Core.Entities
{
    public class Appointment
    {
        public Guid Id { get; set; }
        public decimal Price { get; set; }
        public AppointmentStatus Status { get; set; }
        public Pet Pet { get; set; }
        public TimeSlot TimeSlot { get; set; }
    }
}
