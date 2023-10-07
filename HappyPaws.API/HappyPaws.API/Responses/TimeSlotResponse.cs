using HappyPaws.API.Core.Entities;

namespace HappyPaws.API.Responses
{
    public class TimeSlotResponse
    {
        public Guid Id { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public bool Available { get; set; }
        public Guid DoctorId { get; set; }

        public static TimeSlotResponse FromDomain(TimeSlot timeSlot)
        {
            return new TimeSlotResponse {
                Id = timeSlot.Id,
                Start = timeSlot.Start,
                End = timeSlot.End,
                Available = timeSlot.Available,
                DoctorId = timeSlot.Doctor.Id 
            };
        }
    }
}
