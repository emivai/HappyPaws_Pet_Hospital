using System;

namespace HappyPaws.API.Core.Entities
{
    public class AppointmentProcedure
    {
        public Guid Id { get; set; }
        public Procedure Procedure { get; set; }
        public Appointment Appointment { get; set; }
    }
}
