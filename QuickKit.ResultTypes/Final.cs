namespace QuickKit.ResultTypes;

public record Final : FinalBase
{
    #region Success
    public static Final Success() => new(true, Error.None);

    public static Final<TType> Success<TType>(TType data) => new(true, Error.None, data);
    #endregion

    #region Failure
    public static Final Failure(Error error) => new(false, error);

    public static Final Failure(string code, string message) => new(false, Error.Create(code, message));

    public static Final<TType> Failure<TType>(TType data, string code, string message) => new(false, Error.Create(code, message), data);
    #endregion

    private Final(bool isSuccess, Error error) : base(isSuccess, error) { }
}

public record Final<TType> : FinalBase
{
    public TType Data { get; }

    public static Final<TType> Success(TType data) => new(true, Error.None, data);
    public static Final<TType> Failure(Error error, TType data) => new(false, error, data);
    public static Final<TType> Failure(string code, string message, TType data)
    {
        Error error = Error.Create(code, message);
        return Failure(error, data);
    }

    public Final(bool isSuccess, Error error, TType data) : base(isSuccess, error)
    {
        Data = data;
    }
}
