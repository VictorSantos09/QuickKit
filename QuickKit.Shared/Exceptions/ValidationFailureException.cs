using FluentValidation.Results;
using QuickKit.Shared.Exceptions.Base;

namespace QuickKit.Shared.Exceptions;

/// <summary>
/// Represents an exception that occurs when a validation failure is encountered.
/// </summary>
public class ValidationFailureException : KitException, IException
{
    /// <summary>
    /// Gets the validation result associated with the exception.
    /// </summary>
    public ValidationResult Result { get; }
    public static string? DefaultMessage { get; set; } = "the validation failed";

    /// <summary>
    /// Initializes a new instance of the <see cref="ValidationFailureException"/> class with the specified validation result and message.
    /// </summary>
    /// <param name="result">The validation result associated with the exception.</param>
    /// <param name="message">The error message that explains the reason for the exception.</param>
    public ValidationFailureException(ValidationResult result, string? message) : base(GetMessageToShow(message, DefaultMessage))
    {
        Result = result;
    }
}
