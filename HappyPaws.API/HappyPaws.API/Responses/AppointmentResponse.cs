using HappyPaws.API.Core.Entities;
using HappyPaws.API.Core.Enums;

namespace HappyPaws.API.Responses
{
    public class AppointmentResponse
    {
        public Guid Id { get; set; }
        public decimal Price { get; set; }
        public AppointmentStatus Status { get; set; }
        public PetResponse Pet { get; set; }
        public TimeSlotResponse TimeSlot { get; set; }

        public static AppointmentResponse FromDomain(Appointment appointment)
        {
            return new AppointmentResponse { 
                Id = appointment.Id, 
                Price = appointment.Price, 
                Status = appointment.Status 
            };
        }
    }
}
