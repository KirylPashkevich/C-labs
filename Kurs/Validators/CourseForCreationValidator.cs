using FluentValidation;
using Kurs.DTO;

namespace Kurs.Validators
{
    public class CourseForCreationValidator: AbstractValidator<CourseForCreationDto>
    {
        public CourseForCreationValidator()
        {
            RuleFor(x => x.Title)
               .NotEmpty().WithMessage("Title is required.")
               .MaximumLength(255).WithMessage("Title cannot exceed 255 characters.");

            RuleFor(x => x.Description)
                .NotEmpty()
                .MaximumLength(255).WithMessage("Description is required.");

            RuleFor(x => x.Price)
                .GreaterThan(0).WithMessage("Price must be greater than 0.");

            RuleFor(x => x.DurationHours)
                .GreaterThan(0).WithMessage("Duration must be greater than 0.");
        }
    }
}
