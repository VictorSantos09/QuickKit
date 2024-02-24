using FluentValidation;
using QuickKit.Shared.Entities;

namespace QuickKit.Shared.Validations.Common;

public abstract class Validator<T> : AbstractValidator<T> where T : class, IEntityBase
{
}
