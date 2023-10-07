using HappyPaws.Core.Entities.Common;

namespace HappyPaws.Core.Entities
{
    public class Doctor : Entity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Email { get; set; }
        public int PhoneNumber { get; set; }
        public string? Description { get; set; }
        public string? Photo { get; set; }
        public List<TimeSlot>? TimeSlots { get; set; }
    }
}
