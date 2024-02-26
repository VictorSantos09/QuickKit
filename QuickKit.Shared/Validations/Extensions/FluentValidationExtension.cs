using FluentValidation;
using QuickKit.Shared.Entities;
using QuickKit.Shared.Exceptions;

namespace QuickKit.Shared.Validations.Extensions;

public static class FluentValidationExtension
{
    /// <summary>
    /// Validates the specified entity using the provided validator and throws a ValidationFailureException if the validation fails.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity to validate.</typeparam>
    /// <param name="validator">The validator to use for validation.</param>
    /// <param name="entity">The entity to validate.</param>
    /// <param name="exceptionMessage">The exception message to include if the validation fails.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public static async Task ValidateThrowAsync<TEntity>(this IValidator<TEntity> validator, TEntity entity,
                                                         string exceptionMessage) where TEntity : IEntity
    {
        var result = await validator.ValidateAsync(entity);

        if (!result.IsValid)
        {
            throw new ValidationFailureException(result, $"{typeof(TEntity).Name} {exceptionMessage}");
        }
    }
}
