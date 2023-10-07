using HappyPaws.Core.Entities.Common;

namespace HappyPaws.Core.Entities
{
    public class TimeSlot : Entity
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public bool Available { get; set; }
        public Guid DoctorId { get; set; }
        public Doctor Doctor { get; set; }
    }
}
