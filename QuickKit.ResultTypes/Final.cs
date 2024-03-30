namespace QuickKit.ResultTypes;

public record Final : FinalBase
{
    #region Success
    public static Final Success() => new(true, FinalError.None);

    public static Final<TType> Success<TType>(TType data) => new(true, FinalError.None, data);
    #endregion

    #region Failure
    public static Final Failure(FinalError error) => new(false, error);

    public static Final Failure(string code, string message) => new(false, FinalError.Create(code, message));

    public static Final<TType> Failure<TType>(TType data, string code, string message) => new(false, FinalError.Create(code, message), data);
    #endregion

    private Final(bool isSuccess, FinalError error) : base(isSuccess, error) { }
}

public record Final<TType> : FinalBase
{
    public TType Data { get; }

    public static Final<TType> Success(TType data) => new(true, FinalError.None, data);
    public static Final<TType> Failure(FinalError error, TType data) => new(false, error, data);
    public static Final<TType> Failure(string code, string message, TType data)
    {
        FinalError error = FinalError.Create(code, message);
        return Failure(error, data);
    }

    public Final(bool isSuccess, FinalError error, TType data) : base(isSuccess, error)
    {
        Data = data;
    }
}
