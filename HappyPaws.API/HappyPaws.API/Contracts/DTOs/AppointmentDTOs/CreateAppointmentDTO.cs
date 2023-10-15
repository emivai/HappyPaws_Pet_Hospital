using HappyPaws.Core.Entities;
using HappyPaws.Core.Enums;

namespace HappyPaws.API.Contracts.DTOs.AppointmentDTOs
{
    public class CreateAppointmentDTO
    {
        public Guid PetId { get; set; }
        public Guid TimeSlotId { get; set; }

        public static Appointment ToDomain(CreateAppointmentDTO appointmentDTO)
        {
            return new Appointment
            {
                Status = AppointmentStatus.Scheduled,
                PetId = appointmentDTO.PetId,
                TimeSlotId = appointmentDTO.TimeSlotId
            };
        }
    }
}
