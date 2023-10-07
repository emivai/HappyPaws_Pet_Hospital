using HappyPaws.API.Core.Entities;

namespace HappyPaws.API.Responses
{
    public class NoteResponse
    {
        public Guid Id { get; set; }
        public string Value { get; set; }
        public Guid AppointmentId { get; set; }

        public static NoteResponse FromDomain(Note note)
        {
            return new NoteResponse
            {
                Id = note.Id,
                Value = note.Value,
                AppointmentId = note.Appointment.Id
            };
        }
    }
}
