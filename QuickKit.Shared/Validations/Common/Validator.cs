using FluentValidation;
using QuickKit.Shared.Entities;

namespace QuickKit.Shared.Validations.Common;

/// <summary>
/// Represents a base class for validators used to validate entities.
/// 
/// <para>
/// Inhrerit from this class to create a validator for a specific entity.
/// </para>
/// 
/// <para>
/// This class uses the FluentValidation library to perform the validation.
///  </para>
/// </summary>
/// <typeparam name="TEntity">The type of entity to be validated.</typeparam>
public abstract class Validator<TEntity> : AbstractValidator<TEntity>
    where TEntity : IEntity
{
}
