using HappyPaws.Core.Entities;

namespace HappyPaws.API.Contracts.DTOs.AppointmentProcedureDTOs
{
    public class CreateAppointmentProcedureDTO
    {
        public Guid ProcedureId { get; set; }
        public Guid AppointmentId { get; set; }

        public static AppointmentProcedure ToDomain(CreateAppointmentProcedureDTO appointmentProcedureDTO)
        {
            return new AppointmentProcedure
            {
                ProcedureId = appointmentProcedureDTO.ProcedureId,
                AppointmentId = appointmentProcedureDTO.AppointmentId
            };
        }
    }
}
