using HappyPaws.Core.Entities;

namespace HappyPaws.API.Contracts.Responses
{
    public class DoctorResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Email { get; set; }
        public int PhoneNumber { get; set; }
        public string? Description { get; set; }
        public string? Photo { get; set; }

        public static DoctorResponse FromDomain(Doctor doctor)
        {
            return new DoctorResponse
            {
                Id = doctor.Id,
                Name = doctor.Name,
                Surname = doctor.Surname,
                Email = doctor.Email,
                PhoneNumber = doctor.PhoneNumber,
                Description = doctor.Description,
                Photo = doctor.Photo,
            };
        }
    }
}
