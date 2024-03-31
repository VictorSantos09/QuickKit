namespace QuickKit.ResultTypes
{
    /// <summary>
    /// Represents a final result without any data.
    /// </summary>
    public record Final
    {
        #region Properties
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
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="Final"/> class.
        /// </summary>
        /// <param name="isSuccess">A value indicating whether the result is a success.</param>
        /// <param name="error">The error associated with the result.</param>
        /// <exception cref="ArgumentException">Thrown when the arguments are invalid for creating the result.</exception>
        private protected Final(bool isSuccess, FinalError error)
        {
            if (isSuccess && error != FinalError.None ||
               !isSuccess && error == FinalError.None)
            {
                throw new ArgumentException("Invalid argument for creating result.");
            }

            IsSuccess = isSuccess;
            Error = error;
        }
        #endregion

        #region Success Methods
        /// <summary>
        /// Creates a successful final result without any data.
        /// </summary>
        /// <returns>A successful final result without any data.</returns>
        public static Final Success() => new(true, FinalError.None);

        /// <summary>
        /// Creates a successful final result with the specified data.
        /// </summary>
        /// <typeparam name="TType">The type of the data.</typeparam>
        /// <param name="data">The data to include in the final result.</param>
        /// <returns>A successful final result with the specified data.</returns>
        public static Final<TType> Success<TType>(TType data) => new(true, FinalError.None, data);
        #endregion

        #region Failure Methods
        /// <summary>
        /// Creates a failed final result with the specified error.
        /// </summary>
        /// <param name="error">The error associated with the final result.</param>
        /// <returns>A failed final result with the specified error.</returns>
        public static Final Failure(FinalError error) => new(false, error);

        /// <summary>
        /// Creates a failed final result with the specified error code and message.
        /// </summary>
        /// <param name="code">The error code associated with the final result.</param>
        /// <param name="message">The error message associated with the final result.</param>
        /// <returns>A failed final result with the specified error code and message.</returns>
        public static Final Failure(string code, string message) => new(false, FinalError.Create(code, message));

        /// <summary>
        /// Creates a failed final result with the specified data, error code, and message.
        /// </summary>
        /// <typeparam name="TType">The type of the data.</typeparam>
        /// <param name="data">The data to include in the final result.</param>
        /// <param name="code">The error code associated with the final result.</param>
        /// <param name="message">The error message associated with the final result.</param>
        /// <returns>A failed final result with the specified data, error code, and message.</returns>
        public static Final<TType?> Failure<TType>(TType? data, string code, string message) => new(false, FinalError.Create(code, message), data);
        public static Final<IEnumerable<TType>> Failure<TType>(IEnumerable<TType> data, string code, string message) => new(false, FinalError.Create(code, message), data);
        #endregion
    }

    /// <summary>
    /// Represents a final result with a specific data type.
    /// </summary>
    /// <typeparam name="TType">The type of the data.</typeparam>
    public record Final<TType> : Final
    {
        #region Properties
        /// <summary>
        /// Gets the data associated with the final result.
        /// </summary>
        public TType Data { get; }
        #endregion

        #region Success Methods

        /// <summary>
        /// Creates a successful final result with the specified data.
        /// </summary>
        /// <param name="data">The data to include in the final result.</param>
        /// <returns>A successful final result with the specified data.</returns>
        public static Final<TType> Success(TType data) => new(true, FinalError.None, data);
        #endregion

        #region Failure Methods

        /// <summary>
        /// Creates a failed final result with the specified error and data.
        /// </summary>
        /// <param name="error">The error associated with the final result.</param>
        /// <param name="data">The data to include in the final result.</param>
        /// <returns>A failed final result with the specified error and data.</returns>
        public static Final<TType> Failure(FinalError error, TType data) => new(false, error, data);

        /// <summary>
        /// Creates a failed final result with the specified error code, message, and data.
        /// </summary>
        /// <param name="code">The error code associated with the final result.</param>
        /// <param name="message">The error message associated with the final result.</param>
        /// <param name="data">The data to include in the final result.</param>
        /// <returns>A failed final result with the specified error code, message, and data.</returns>
        public static Final<TType> Failure(string code, string message, TType data)
        {
            FinalError error = FinalError.Create(code, message);
            return Failure(error, data);
        }
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="Final{TType}"/> class.
        /// </summary>
        /// <param name="isSuccess">Indicates whether the final result is successful.</param>
        /// <param name="error">The error associated with the final result.</param>
        /// <param name="data">The data associated with the final result.</param>
        public Final(bool isSuccess, FinalError error, TType data) : base(isSuccess, error)
        {
            Data = data;
        }
        #endregion
    }
}
