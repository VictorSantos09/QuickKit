using FluentValidation.Results;

namespace QuickKit.Exceptions;

public class ValidationFailureException : Exception
{
    public ValidationResult Result { get; }

    public ValidationFailureException(ValidationResult result, string? message) : base(message)
    {
        Result = result;
    }
}
