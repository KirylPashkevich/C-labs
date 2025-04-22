using FluentValidation;
using Kurs.DTO;

namespace Kurs.Validators
{
    public class LessonForCreationValidator : AbstractValidator<LessonForCreationDto>
    {
        public LessonForCreationValidator()
        {
            RuleFor(x => x.DateTime)
                .NotEmpty().WithMessage("DateTime is required.")
                .Must(BeAValidDateTime).WithMessage("DateTime must be in the future.");

            RuleFor(x => x.LessonType)
                .NotEmpty().WithMessage("LessonType is required.")
                .MaximumLength(50).WithMessage("LessonType cannot exceed 50 characters.");

            RuleFor(x => x.Description)
                .MaximumLength(500).WithMessage("Description cannot exceed 500 characters."); // Description не обязательное, но ограничим длину
        }

        private bool BeAValidDateTime(DateTime dateTime)
        {
            return dateTime > DateTime.Now;
        }
    }

}
