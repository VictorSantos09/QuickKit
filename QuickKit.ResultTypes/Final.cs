namespace QuickKit.ResultTypes;

/// <summary>
/// Represents a final result without any data.
/// </summary>
/// <summary>
/// Represents a final result that can be either a success or a failure.
/// </summary>
public record Final : IFinal
    {
        #region Properties
        /// <inheritdoc/>
        public bool IsSuccess { get; }

        /// <inheritdoc/>
        public bool IsFailure => !IsSuccess;
        /// <inheritdoc/>
        public IFinalError Error { get; }
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="Final"/> class.
        /// </summary>
        /// <param name="isSuccess">A value indicating whether the result is a success.</param>
        /// <param name="error">The error associated with the result.</param>
        /// <exception cref="ArgumentException">Thrown when the arguments are invalid for creating the result.</exception>
        public Final(bool isSuccess, IFinalError error)
        {
            if (isSuccess && error != IFinalError.None ||
               !isSuccess && error == IFinalError.None)
            {
                throw new ArgumentException("Invalid argument for creating result.");
            }

            IsSuccess = isSuccess;
            Error = error;
        }

        private Final()
        {
                
        }
        #endregion

        #region Success Methods
        /// <summary>
        /// Creates a successful final result without any data.
        /// </summary>
        /// <returns>A successful final result without any data.</returns>
        public static IFinal Success()
        {
            return new Final(true, IFinalError.None);
        }

        /// <summary>
        /// Creates a successful final result with the specified data.
        /// </summary>
        /// <typeparam name="TType">The type of the data.</typeparam>
        /// <param name="data">The data to include in the final result.</param>
        /// <returns>A successful final result with the specified data.</returns>
        public static IFinal<TType> Success<TType>(TType data)
        {
            return new Final<TType>(true, IFinalError.None, data);
        }
        #endregion

        #region Failure Methods
        /// <summary>
        /// Creates a failed final result with the specified error.
        /// </summary>
        /// <param name="error">The error associated with the final result.</param>
        /// <returns>A failed final result with the specified error.</returns>
        public static IFinal Failure(IFinalError error)
        {
            return new Final(false, error);
        }

        /// <summary>
        /// Creates a failed final result with the specified error code and message.
        /// </summary>
        /// <param name="code">The error code associated with the final result.</param>
        /// <param name="message">The error message associated with the final result.</param>
        /// <returns>A failed final result with the specified error code and message.</returns>
        public static IFinal Failure(string code, string message)
        {
            return new Final(false, FinalError.Create(code, message));
        }

        /// <summary>
        /// Creates a failed final result with the specified data, error code, and message.
        /// </summary>
        /// <typeparam name="TType">The type of the data.</typeparam>
        /// <param name="data">The data to include in the final result.</param>
        /// <param name="code">The error code associated with the final result.</param>
        /// <param name="message">The error message associated with the final result.</param>
        /// <returns>A failed final result with the specified data, error code, and message.</returns>
        public static IFinal<TType?> Failure<TType>(TType? data, string code, string message)
        {
            return new Final<TType?>(false, FinalError.Create(code, message), data);
        }

        /// <inheritdoc/>
        public static IFinal<IEnumerable<TType>> Failure<TType>(IEnumerable<TType> data, string code, string message)
        {
            return new Final<IEnumerable<TType>>(false, FinalError.Create(code, message), data);
        }
        #endregion
    }

/// <summary>
/// Represents a final result that can either be successful or failed, with associated data of type <typeparamref name="TType"/>.
/// </summary>
/// <typeparam name="TType">The type of the data associated with the final result.</typeparam>
public record Final<TType> : Final, IFinal<TType>
{
    #region Properties
    /// <inheritdoc/>
    public TType Data { get; }
    #endregion

    #region Success Methods

    /// <summary>
    /// Creates a successful final result with the specified data.
    /// </summary>
    /// <param name="data">The data to include in the final result.</param>
    /// <returns>A successful final result with the specified data.</returns>
    public static IFinal<TType> Success(TType data) => new Final<TType>(true, IFinalError.None, data);
    #endregion

    #region Failure Methods

    /// <summary>
    /// Creates a failed final result with the specified error and data.
    /// </summary>
    /// <param name="error">The error associated with the final result.</param>
    /// <param name="data">The data to include in the final result.</param>
    /// <returns>A failed final result with the specified error and data.</returns>
    public static IFinal<TType> Failure(IFinalError error, TType data) => new Final<TType>(false, error, data);

    /// <summary>
    /// Creates a failure result with the specified error code, message, and data.
    /// </summary>
    /// <typeparam name="TType">The type of the data.</typeparam>
    /// <param name="code">The error code.</param>
    /// <param name="message">The error message.</param>
    /// <param name="data">The data associated with the failure result.</param>
    /// <returns>An instance of <see cref="IFinal{TType}"/> representing the failure result.</returns>
    public static IFinal<TType> Failure(string code, string message, TType data)
    {
        IFinalError error = FinalError.Create(code, message);
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
    public Final(bool isSuccess, IFinalError error, TType data) : base(isSuccess, error)
    {
        Data = data;
    }
    #endregion
}
