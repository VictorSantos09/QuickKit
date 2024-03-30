namespace QuickKit.ResultTypes;

/// <summary>
/// Represents a final error result.
/// </summary>
public record FinalError
{
    /// <summary>
    /// Gets the default instance of <see cref="FinalError"/>.
    /// </summary>
    public static readonly FinalError None = new(string.Empty, string.Empty);

    /// <summary>
    /// Gets the error code.
    /// </summary>
    public string Code { get; }

    /// <summary>
    /// Gets the error message.
    /// </summary>
    public string Message { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="FinalError"/> class.
    /// </summary>
    /// <param name="code">The error code.</param>
    /// <param name="message">The error message.</param>
    private protected FinalError(string code, string message)
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
    /// Implicitly converts a <see cref="FinalError"/> to a <see cref="Final"/> with failure status.
    /// </summary>
    /// <param name="error">The error to convert.</param>
    /// <returns>A <see cref="Final"/> with failure status.</returns>
    public static implicit operator Final(FinalError error) => Final.Failure(error);

    /// <summary>
    /// Creates a new instance of <see cref="FinalError"/> with the specified code and message.
    /// </summary>
    /// <param name="code">The error code.</param>
    /// <param name="message">The error message.</param>
    /// <returns>A new instance of <see cref="FinalError"/>.</returns>
    public static FinalError Create(string code, string message) => new(code, message);
}
