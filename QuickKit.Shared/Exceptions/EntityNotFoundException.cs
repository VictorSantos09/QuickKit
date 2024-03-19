using QuickKit.Shared.Exceptions.Base;

namespace QuickKit.Shared.Exceptions;

/// <summary>
/// Represents an exception that is thrown when an entity is not found.
/// </summary>
public class EntityNotFoundException : KitException, IException
{
    /// <summary>
    /// Initializes a new instance of the <see cref="EntityNotFoundException"/> class with a specified error message.
    /// </summary>
    /// <param name="message">The error message that explains the reason for the exception.</param>
    public EntityNotFoundException(string message) : base(GetMessageToShow(message, DefaultMessage))
    {
    }

    public static string? DefaultMessage { get; set; } = "Entity was not found";
}
