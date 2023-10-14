using HappyPaws.Core.Entities;

namespace HappyPaws.API.Contracts.DTOs.DoctorDTOs
{
    public class CreateDoctorDTO
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Email { get; set; }
        public int PhoneNumber { get; set; }
        public string? Description { get; set; }
        public string? Photo { get; set; }

        public static Doctor ToDomain(CreateDoctorDTO doctorDTO)
        {
            return new Doctor
            {
                Name = doctorDTO.Name,
                Surname = doctorDTO.Surname,
                Email = doctorDTO.Email,
                PhoneNumber = doctorDTO.PhoneNumber,
                Description = doctorDTO.Description,
                Photo = doctorDTO.Photo,
            };
        }
    }
}
