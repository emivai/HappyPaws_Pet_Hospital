using FluentValidation;
using HappyPaws.API.Contracts.DTOs.PetDTOs;

namespace HappyPaws.API.Validators
{
    public class CreatePetValidator : AbstractValidator<CreatePetDTO>
    {
        private const string OnlyLettersAndWhiteSpace = @"^[\p{L}\s']*$";

        public CreatePetValidator() 
        {
            RuleFor(pet => pet.Type).NotNull().IsInEnum().WithMessage("Type invalid. Valid pet type values are: 0 (dog), 1 (cat), 2 (rodent) and 3 (exotic).");

            RuleFor(pet => pet.Name).NotNull().NotEmpty().WithMessage("Name is required.");
            RuleFor(pet => pet.Name).Length(1, 50).WithMessage("Name has to be 1-50 characters long.");
            RuleFor(pet => pet.Name).Matches(OnlyLettersAndWhiteSpace).WithMessage("Name cannot contain numbers or special symbols.");

            RuleFor(pet => pet.BirthDate).NotNull().LessThanOrEqualTo(DateTime.Now);
        }
    }

    public class UpdatePetValidator : AbstractValidator<UpdatePetDTO>
    {
        private const string OnlyLettersAndWhiteSpace = @"^[\p{L}\s']*$";

        public UpdatePetValidator()
        {
            RuleFor(pet => pet.Type).NotNull().IsInEnum().WithMessage("Type invalid. Valid pet type values are: 0 (dog), 1 (cat), 2 (rodent) and 3 (exotic).");

            RuleFor(pet => pet.Name).NotNull().NotEmpty().WithMessage("Name is required.");
            RuleFor(pet => pet.Name).Length(1, 50).WithMessage("Name has to be 1-50 characters long.");
            RuleFor(pet => pet.Name).Matches(OnlyLettersAndWhiteSpace).WithMessage("Name cannot contain numbers or special symbols.");

            RuleFor(pet => pet.BirthDate).NotNull().LessThanOrEqualTo(DateTime.Now);
        }
    }
}
