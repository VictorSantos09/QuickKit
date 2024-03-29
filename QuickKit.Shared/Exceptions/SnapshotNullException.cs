using QuickKit.Shared.Exceptions.Base;

namespace QuickKit.Shared.Exceptions;

/// <summary>
/// Represents an exception that is thrown when a snapshot is null.
/// </summary>
public class SnapshotNullException : KitException, IException
{
    /// <summary>
    /// Initializes a new instance of the <see cref="SnapshotNullException"/> class with a specified error message.
    /// </summary>
    /// <param name="message">The error message that explains the reason for the exception.</param>
    public SnapshotNullException(string message) : base(GetMessageToShow(message, DefaultMessage))
    {
    }

    public static string? DefaultMessage { get; set; } = "the snapshot was null";
}
