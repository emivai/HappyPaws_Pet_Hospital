namespace HappyPaws.API.Core.Entities
{
    public class Note
    {
        public Guid Id { get; set; }
        public string Value { get; set; } 
        public Appointment Appointment { get; set; }
    }
}
