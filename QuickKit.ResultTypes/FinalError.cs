namespace QuickKit.ResultTypes
{
    public record FinalError
    {
        public static readonly FinalError None = new(string.Empty, string.Empty);
        public string Code { get; }
        public string Message { get; }

        private protected FinalError(string code, string message)
        {
            Code = code;
            Message = message;
        }

        private FinalError()
        {

        }

        public static implicit operator Final(FinalError error) => Final.Failure(error);
        public static FinalError Create(string code, string message) => new(code, message);
    }
}
