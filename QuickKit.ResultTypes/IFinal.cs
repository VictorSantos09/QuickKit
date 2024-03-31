namespace QuickKit.ResultTypes;

/// <summary>
/// Represents the final result of an operation with associated data.
/// </summary>
/// <typeparam name="TType">The type of the data associated with the final result.</typeparam>
public interface IFinal<TType> : IFinal
{
    #region Properties
    /// <summary>
    /// Gets the data associated with the final result.
    /// </summary>
    TType Data { get; }
    #endregion
}
public interface IFinal
{
    #region Properties
    /// <summary>
    /// Gets a value indicating whether the result is a success.
    /// </summary>
    bool IsSuccess { get; }

    /// <summary>
    /// Gets a value indicating whether the result is a failure.
    /// </summary>
    bool IsFailure => !IsSuccess;

    /// <summary>
    /// Gets the error associated with the result.
    /// </summary>
    IFinalError Error { get; }
    #endregion
}
