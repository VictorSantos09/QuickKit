namespace QuickKit.ResultTypes.ValueObjects
{
    #region ResultBase
    public abstract record ResultBase
    {
        public bool IsSuccess { get; }
        public bool IsFailure => !IsSuccess;
        public Error Error { get; }

        private protected ResultBase(bool isSuccess, Error error)
        {
            if (isSuccess && error != Error.None ||
               !isSuccess && error == Error.None)
            {
                throw new ArgumentException("invalid argument for creating result");
            }

            IsSuccess = isSuccess;
            Error = error;
        }
    }
    #endregion

    #region Result
    public record Result : ResultBase
    {
        #region Success
        public static Result Success() => new(true, Error.None);

        public static Result<TType> Success<TType>(TType data) => new(true, Error.None, data);
        #endregion

        #region Failure
        public static Result Failure(Error error) => new(false, error);

        public static Result Failure(string code, string message)
            => new(false, Error.Create(code, message));

        public static Result<TType> Failure<TType>(TType data, string code, string message)
            => new(false, Error.Create(code, message), data);
        #endregion

        private Result(bool isSuccess, Error error) : base(isSuccess, error) { }
    }

    public record Result<TType> : ResultBase
    {
        public TType Data { get; }

        public static Result<TType> Success(TType data) => new(true, Error.None, data);
        public static Result<TType> Failure(Error error, TType data) => new(false, error, data);
        public static Result<TType> Failure(string code, string message, TType data)
        {
            Error error = Error.Create(code, message);
            return Failure(error, data);
        }

        public Result(bool isSuccess, Error error, TType data) : base(isSuccess, error)
        {
            Data = data;
        }
    }
    #endregion
}
