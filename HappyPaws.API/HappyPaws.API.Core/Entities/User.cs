using HappyPaws.API.Core.Enums;

namespace HappyPaws.API.Core.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public UserType Type { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public List<Pet>? Pets { get; set; } 
    }
}
