﻿using HappyPaws.Core.Entities;

namespace HappyPaws.API.Contracts.DTOs.NoteDTOs
{
    public class CreateNoteDTO
    {
        public string Value { get; set; }
        public Guid AppointmentId { get; set; }

        public static Note ToDomain(CreateNoteDTO noteDTO)
        {
            return new Note
            {
                Value = noteDTO.Value,
                AppointmentId = noteDTO.AppointmentId
            };
        }
    }
}
