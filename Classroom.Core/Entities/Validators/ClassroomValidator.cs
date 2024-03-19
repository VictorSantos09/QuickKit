using FluentValidation;

namespace Classroom.Core.Entities.Validators
{
    public class ClassroomValidator : AbstractValidator<ClassroomEntity>
    {
        public ClassroomValidator()
        {
            RuleFor(x => x.ClassroomName).NotEmpty();
        }
    }
}
