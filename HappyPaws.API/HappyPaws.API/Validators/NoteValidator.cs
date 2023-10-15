using FluentValidation;
using HappyPaws.API.Contracts.DTOs.NoteDTOs;

namespace HappyPaws.API.Validators
{
    public class CreateNoteValidator : AbstractValidator<CreateNoteDTO>
    {
        public CreateNoteValidator() 
        {
            RuleFor(note => note.Value).NotEmpty().WithMessage("Value is required.");
            RuleFor(note => note.Value).Length(1, 250).WithMessage("Value has to be 1-250 characters long.");

            RuleFor(note => note.AppointmentId).NotNull().WithMessage("AppointmentId is required.");
        }
    }

    public class UpdateNoteValidator : AbstractValidator<UpdateNoteDTO>
    {
        public UpdateNoteValidator()
        {
            RuleFor(note => note.Value).NotEmpty().WithMessage("Value is required.");
            RuleFor(note => note.Value).Length(1, 250).WithMessage("Value has to be 1-250 characters long.");
        }
    }
}
