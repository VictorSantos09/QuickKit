using FluentValidation;
using QuickKit.Shared.Entities;
using QuickKit.Shared.Exceptions;

namespace QuickKit.Shared.Validations.Extensions;

public static class FluentValidationExtension
{
    public static async Task ValidateThrowAsync<TEntity>(this IValidator<TEntity> validator, TEntity entity,
                                                         string exceptionMessage) where TEntity : class, IEntityBase
    {
        var result = await validator.ValidateAsync(entity);

        if (!result.IsValid)
        {
            throw new ValidationFailureException(result, $"{typeof(TEntity).Name} {exceptionMessage}");
        }
    }
}
