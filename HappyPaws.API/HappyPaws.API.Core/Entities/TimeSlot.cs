namespace HappyPaws.API.Core.Entities
{
    public class TimeSlot
    {
        public Guid Id { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public bool Available { get; set; }
        public Doctor Doctor { get; set; }
    }
}
