using FluentValidation;
using Kurs.DTO;

namespace Kurs.Validators
{
    public class StudentForCreationValidator : AbstractValidator<StudentForCreationDto>
    {
        public StudentForCreationValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("First Name is required.")
                .MaximumLength(50).WithMessage("First Name cannot exceed 50 characters.");

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Last Name is required.")
                .MaximumLength(50).WithMessage("Last Name cannot exceed 50 characters.");

            RuleFor(x => x.MiddleName)
                .MaximumLength(50).WithMessage("Middle Name cannot exceed 50 characters.");

            RuleFor(x => x.DateOfBirth)
                .NotEmpty().WithMessage("Date of Birth is required.")
                .Must(BeAValidDateOfBirth).WithMessage("Date of Birth must be in the past.")
                .LessThan(DateTime.Now.AddYears(-6)).WithMessage("Student must be at least 6 years old.");

            RuleFor(x => x.Address)
                .NotEmpty().WithMessage("Address is required.")
                .MaximumLength(200).WithMessage("Address cannot exceed 200 characters.");

            RuleFor(x => x.Phone)
                .NotEmpty().WithMessage("Phone number is required.")
                .Matches(@"^\+?\d{1,3}[-.\s]?\(?\d{1,4}\)?[-.\s]?\d{1,4}[-.\s]?\d{1,9}$")
                .WithMessage("Invalid phone number format.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Invalid email address format.");

            RuleFor(x => x.GroupID)
                .GreaterThan(0).WithMessage("GroupID must be greater than 0.");
        }

        private bool BeAValidDateOfBirth(DateTime dateOfBirth)
        {
            return dateOfBirth < DateTime.Now;
        }
    }
}
