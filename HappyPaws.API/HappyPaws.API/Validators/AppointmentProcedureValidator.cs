using FluentValidation;
using HappyPaws.API.Contracts.DTOs.AppointmentProcedureDTOs;

namespace HappyPaws.API.Validators
{
    public class CreateAppointmentProcedureValidator : AbstractValidator<CreateAppointmentProcedureDTO>
    {
        public CreateAppointmentProcedureValidator()
        {
            RuleFor(appointmentProcedure => appointmentProcedure.ProcedureId).NotEmpty().WithMessage("ProcedureId is required.");

            RuleFor(appointmentProcedure => appointmentProcedure.AppointmentId).NotEmpty().WithMessage("AppointmentId is required.");
        }
    }

    public class UpdateAppointmentProcedureValidator : AbstractValidator<UpdateAppointmentProcedureDTO>
    {
        public UpdateAppointmentProcedureValidator()
        {
            RuleFor(appointmentProcedure => appointmentProcedure.ProcedureId).NotEmpty().WithMessage("ProcedureId is required.");

            RuleFor(appointmentProcedure => appointmentProcedure.AppointmentId).NotEmpty().WithMessage("AppointmentId is required.");
        }
    }
}
