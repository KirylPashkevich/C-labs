using FluentValidation;
using Kurs.DTO;

namespace Kurs.Validators
{
    public class GroupForCreationValidator: AbstractValidator<GroupForCreationDto>
    {
       
            public GroupForCreationValidator()
            {
                RuleFor(x => x.Name)
                    .NotEmpty().WithMessage("Group Name is required.")
                    .MaximumLength(100).WithMessage("Group Name cannot exceed 100 characters.");

                RuleFor(x => x.StartDate)
                    .NotEmpty().WithMessage("Start Date is required.")
                    .Must(BeAValidStartDate).WithMessage("Start Date must be in the future.");

                RuleFor(x => x.EndDate)
                    .NotEmpty().WithMessage("End Date is required.")
                    .GreaterThan(x => x.StartDate).WithMessage("End Date must be after Start Date.");

                RuleFor(x => x.MaxStudents)
                    .GreaterThan(0).WithMessage("Max Students must be greater than 0.")
                    .LessThanOrEqualTo(50).WithMessage("Max Students cannot exceed 50.");

                RuleFor(x => x.CourseID)
                    .GreaterThan(0).WithMessage("Course ID must be greater than 0.");

                RuleFor(x => x.StudentID)
                    .GreaterThan(0).WithMessage("Student ID must be greater than 0.");

                RuleFor(x => x.GroupID)
                   .GreaterThan(0).WithMessage("Group ID must be greater than 0.");
            }

            private bool BeAValidStartDate(DateTime startDate)
            {
                return startDate > DateTime.Now;
            }
        }
    
}
