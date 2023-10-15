using HappyPaws.Core.Entities.Common;
using HappyPaws.Core.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace HappyPaws.Core.Entities
{
    public class Appointment : Entity
    {
        [NotMapped]
        public decimal Price { get; set; } = 0;
        public AppointmentStatus Status { get; set; }
        public Guid PetId { get; set; }
        public Guid TimeSlotId { get; set; }
        public Pet Pet { get; set; }
        public TimeSlot TimeSlot { get; set; }
        public List<Note>? Notes { get; set; }

        public List<AppointmentProcedure> AppointmentProcedures { get; set; } = new List<AppointmentProcedure> { };

        public void CalculateTotalPrice()
        {
            if(AppointmentProcedures.Count != 0)
            {
                foreach (var procedure in AppointmentProcedures)
                {
                    this.Price += procedure.Procedure.Price;
                }
            }
        }
    }
}
