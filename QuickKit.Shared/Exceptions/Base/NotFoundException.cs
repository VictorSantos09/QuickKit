namespace QuickKit.Shared.Exceptions.Base;

/// <summary>
/// Represents an exception that is thrown when a resource is not found.
/// </summary>
public class NotFoundException : KitException, IException
{

    /// <summary>
    /// Initializes a new instance of the <see cref="NotFoundException"/> class with a specified error message.
    /// </summary>
    /// <param name="message">The error message that explains the reason for the exception.</param>
    public NotFoundException(string message) : base(GetMessageToShow(message, DefaultMessage))
    {

    }

    public static string? DefaultMessage { get; set; } = "content not found";
}