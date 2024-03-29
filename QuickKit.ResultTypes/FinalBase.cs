namespace QuickKit.ResultTypes
{
    #region FinalBase
    public abstract record FinalBase
    {
        public bool IsSuccess { get; }
        public bool IsFailure => !IsSuccess;
        public Error Error { get; }

        private protected FinalBase(bool isSuccess, Error error)
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
}
