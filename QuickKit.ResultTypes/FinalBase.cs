namespace QuickKit.ResultTypes;

#region FinalBase
public abstract record FinalBase
{
    public bool IsSuccess { get; }
    public bool IsFailure => !IsSuccess;
    public FinalError Error { get; }

    private protected FinalBase(bool isSuccess, FinalError error)
    {
        if (isSuccess && error != FinalError.None ||
           !isSuccess && error == FinalError.None)
        {
            throw new ArgumentException("invalid argument for creating result");
        }

        IsSuccess = isSuccess;
        Error = error;
    }
}
#endregion
