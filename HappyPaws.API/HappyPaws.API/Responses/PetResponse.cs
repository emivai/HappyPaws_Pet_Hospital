using HappyPaws.API.Core.Entities;
using HappyPaws.API.Core.Enums;

namespace HappyPaws.API.Responses
{
    public class PetResponse
    {
        public Guid Id { get; set; }
        public AnimalType Type { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string? Photo { get; set; }
        public Guid OwnerId { get; set; }

        public static PetResponse FromDomain(Pet pet)
        {
            return new PetResponse
            {
                Id = pet.Id,
                Type = pet.Type,
                Name = pet.Name,
                BirthDate = pet.BirthDate,
                Photo = pet.Photo,
                OwnerId = pet.Owner.Id
            };
        }
    }
}
