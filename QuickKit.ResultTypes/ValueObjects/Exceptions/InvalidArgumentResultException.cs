using QuickKit.Shared.Exceptions.Base;

namespace QuickKit.ResultTypes.ValueObjects.Exceptions
{
    public class InvalidArgumentResultException : KitException, IException
    {
        public InvalidArgumentResultException(string message) : base(GetMessageToShow(message, DefaultMessage))
        {
        }

        public static string? DefaultMessage { get; set; }
    }
}
