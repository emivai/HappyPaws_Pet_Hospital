using HappyPaws.API.Core.Entities;

namespace HappyPaws.API.Responses
{
    public class AppointmentProcedureResponse
    {
        public Guid Id { get; set; }
        public Guid ProcedureId { get; set; }
        public Guid AppointmentId { get; set; }

        public static AppointmentProcedureResponse FromDomain(AppointmentProcedure appointmentProcedure)
        {
            return new AppointmentProcedureResponse {
                Id = appointmentProcedure.Id,
                ProcedureId = appointmentProcedure.Procedure.Id,
                AppointmentId = appointmentProcedure.Appointment.Id
            };
        }
    }
}
