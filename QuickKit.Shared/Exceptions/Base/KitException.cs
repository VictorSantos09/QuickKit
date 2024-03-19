using QuickKit.Shared.Extensions;

namespace QuickKit.Shared.Exceptions.Base;

public abstract class KitException : Exception
{
    private const string DEFAULT_LOW_LEVEL_EXCEPTION = "an exception was thrown";
    protected KitException(string? message) : base(GetMessageToShow(message, DEFAULT_LOW_LEVEL_EXCEPTION))
    {
    }

    private protected static string? GetMessageToShow(string? message, string? defaultMessage)
    {
        if (message.IsEmpty()) return defaultMessage;
        else return message;
    }
}

public interface IException
{
    abstract static string? DefaultMessage { get; set; }
}