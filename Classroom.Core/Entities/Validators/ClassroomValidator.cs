using FluentValidation;
using QuickKit.Shared.Validations.Common;

namespace Classroom.Core.Entities.Validators;

public class ClassroomValidator : Validator<ClassroomEntity>
{
    public ClassroomValidator()
    {
        _ = RuleFor(x => x.ClassroomName).NotEmpty();
    }
}
