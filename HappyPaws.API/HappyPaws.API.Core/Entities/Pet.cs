using HappyPaws.API.Core.Enums;
using System;

namespace HappyPaws.API.Core.Entities
{
    public class Pet
    {
        public Guid Id { get; set; }
        public AnimalType Type { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string Photo { get; set; }
        public User Owner { get; set; }
    }
}
