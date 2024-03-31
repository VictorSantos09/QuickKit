namespace QuickKit.ResultTypes;

public interface IFinalError
{
    #region Properties
    /// <summary>
    /// Gets the default instance of <see cref="IFinalError"/>.
    /// </summary>
    public static readonly IFinalError None = new FinalError(string.Empty, string.Empty);

    /// <summary>
    /// Gets the error code.
    /// </summary>
    public string Code { get; }

    /// <summary>
    /// Gets the error message.
    /// </summary>
    public string Message { get; }
    #endregion
}
