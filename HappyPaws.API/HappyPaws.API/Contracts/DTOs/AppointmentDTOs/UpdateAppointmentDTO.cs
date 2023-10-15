using HappyPaws.Core.Entities;
using HappyPaws.Core.Enums;

namespace HappyPaws.API.Contracts.DTOs.AppointmentDTOs
{
    public class UpdateAppointmentDTO
    {
        public AppointmentStatus Status { get; set; }
        public Guid PetId { get; set; }
        public Guid TimeSlotId { get; set; }

        public static Appointment ToDomain(UpdateAppointmentDTO appointmentDTO)
        {
            return new Appointment
            {
                Status = appointmentDTO.Status,
                PetId = appointmentDTO.PetId,
                TimeSlotId = appointmentDTO.TimeSlotId
            };
        }
    }
}
