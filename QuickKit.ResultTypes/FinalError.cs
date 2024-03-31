namespace QuickKit.ResultTypes;

/// <summary>
/// Represents a final error result.
/// </summary>
public record FinalError : IFinalError
{
    /// <inheritdoc/>
    public string Code { get; }

    /// <inheritdoc/>
    public string Message { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="FinalError"/> class.
    /// </summary>
    /// <param name="code">The error code.</param>
    /// <param name="message">The error message.</param>
    public FinalError(string code, string message)
    {
        Code = code;
        Message = message;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="FinalError"/> class.
    /// </summary>
    private FinalError()
    {

    }

    /// <summary>
    /// Creates a new instance of <see cref="FinalError"/> with the specified code and message.
    /// </summary>
    /// <param name="code">The error code.</param>
    /// <param name="message">The error message.</param>
    /// <returns>A new instance of <see cref="FinalError"/>.</returns>
    public static IFinalError Create(string code, string message) => new FinalError(code, message);
}
