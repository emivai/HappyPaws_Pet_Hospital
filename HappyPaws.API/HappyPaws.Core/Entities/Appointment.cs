using HappyPaws.Core.Entities.Common;
using HappyPaws.Core.Enums;

namespace HappyPaws.Core.Entities
{
    public class Appointment : Entity
    {
        public decimal Price { get; set; }
        public AppointmentStatus Status { get; set; }
        public Guid PetId { get; set; }
        public Guid TimeSlotId { get; set; }
        public Pet Pet { get; set; }
        public TimeSlot TimeSlot { get; set; }
    }
}
