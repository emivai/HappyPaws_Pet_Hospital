using System;

namespace HappyPaws.API.Core.Entities
{
    public class Doctor
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Email { get; set; }
        public int PhoneNumber { get; set; }
        public string Description { get; set; }
        public string Photo { get; set; }
    }
}
