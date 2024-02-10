using FluentValidation;
using QuickKit.Entities;

namespace QuickKit.Validations.Common;

public abstract class Validator<T> : AbstractValidator<T> where T : class, IEntityBase
{
}
