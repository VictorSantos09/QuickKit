namespace QuickKit.ResultTypes;

#region FinalBase
/// <summary>
/// Represents the base class for final result types.
/// </summary>
public abstract record FinalBase
{
    /// <summary>
    /// Gets a value indicating whether the result is a success.
    /// </summary>
    public bool IsSuccess { get; }

    /// <summary>
    /// Gets a value indicating whether the result is a failure.
    /// </summary>
    public bool IsFailure => !IsSuccess;

    /// <summary>
    /// Gets the error associated with the result.
    /// </summary>
    public FinalError Error { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="FinalBase"/> class.
    /// </summary>
    /// <param name="isSuccess">A value indicating whether the result is a success.</param>
    /// <param name="error">The error associated with the result.</param>
    /// <exception cref="ArgumentException">Thrown when the arguments are invalid for creating the result.</exception>
    private protected FinalBase(bool isSuccess, FinalError error)
    {
        if (isSuccess && error != FinalError.None ||
           !isSuccess && error == FinalError.None)
        {
            throw new ArgumentException("Invalid argument for creating result.");
        }

        IsSuccess = isSuccess;
        Error = error;
    }
}
#endregion
