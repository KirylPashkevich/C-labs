using FluentValidation;
using Kurs.DTO;

namespace Kurs.Validators
{
    public class InstructorForCreationValidator : AbstractValidator<InstructorForCreationDto>
    {
        public InstructorForCreationValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("First Name is required.")
                .MaximumLength(50).WithMessage("First Name cannot exceed 50 characters.");

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Last Name is required.")
                .MaximumLength(50).WithMessage("Last Name cannot exceed 50 characters.");

            RuleFor(x => x.MiddleName)
                .MaximumLength(50).WithMessage("Middle Name cannot exceed 50 characters."); // Middle Name не обязателен, но ограничим длину

            RuleFor(x => x.DateOfBirth)
                .Must(BeAValidDateOfBirth).WithMessage("Date of Birth must be in the past.")
                .LessThan(DateTime.Now.AddYears(-18)).WithMessage("Instructor must be at least 18 years old."); // Добавим требование возраста

            RuleFor(x => x.Address)
                .NotEmpty().WithMessage("Address is required.")
                .MaximumLength(200).WithMessage("Address cannot exceed 200 characters.");

            RuleFor(x => x.Phone)
                .NotEmpty().WithMessage("Phone number is required.")
                .Matches(@"^\+?\d{1,3}[-.\s]?\(?\d{1,4}\)?[-.\s]?\d{1,4}[-.\s]?\d{1,9}$")
                .WithMessage("Invalid phone number format."); // Простая валидация формата телефона

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Invalid email address format.");

            RuleFor(x => x.ExperienceYears)
                .GreaterThanOrEqualTo(0).WithMessage("Experience Years must be a non-negative number.")
                .LessThanOrEqualTo(70).WithMessage("Experience Years must be less than 70."); //Ограничение сверху, чтобы избежать нереалистичных значений
        }

        private bool BeAValidDateOfBirth(DateTime? dateOfBirth)
        {
            // Если DateOfBirth не указана, считаем валидной (может быть nullable)
            if (!dateOfBirth.HasValue)
            {
                return true;
            }

            // Проверяем, что дата рождения в прошлом
            return dateOfBirth.Value < DateTime.Now;
        }
    }

}
