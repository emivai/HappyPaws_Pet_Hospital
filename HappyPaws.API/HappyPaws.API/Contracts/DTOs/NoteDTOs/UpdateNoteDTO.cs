using HappyPaws.Core.Entities;

namespace HappyPaws.API.Contracts.DTOs.NoteDTOs
{
    public class UpdateNoteDTO
    {
        public string Value { get; set; }

        public static Note ToDomain(UpdateNoteDTO noteDTO)
        {
            return new Note
            {
                Value = noteDTO.Value
            };
        }
    }
}
