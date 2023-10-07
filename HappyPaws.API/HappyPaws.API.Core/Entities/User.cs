using System;
using System.Collections.Generic;

namespace HappyPaws.API.Core.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Email { get; set; }
        public int PhoneNumber { get; set; }
        public List<Pet>? Pets { get; set; } 
    }
}
