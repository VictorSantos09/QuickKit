namespace QuickKit.ResultTypes.ValueObjects
{
    public record Error
    {
        public static readonly Error None = new(string.Empty, string.Empty);
        public string Code { get; }
        public string Message { get; }

        private protected Error(string code, string message)
        {
            Code = code;
            Message = message;
        }

        private Error()
        {

        }

        public static implicit operator Result(Error error) => Result.Failure(error);
        public static Error Create(string code, string message) => new(code, message);
    }
}
