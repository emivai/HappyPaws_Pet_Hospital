using HappyPaws.API.Core.Enums;

namespace HappyPaws.API.Responses
{
    public class UserResponse
    {
        public Guid Id { get; set; }
        public UserType Type { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public static UserResponse FromDomain(UserResponse user)
        {
            return new UserResponse
            {
                Id = user.Id,
                Type = user.Type,
                Name = user.Name,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber
            };
        }
    }
}
