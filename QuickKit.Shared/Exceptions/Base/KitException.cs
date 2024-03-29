using QuickKit.Shared.Extensions;

namespace QuickKit.Shared.Exceptions.Base;

public abstract class KitException : Exception
{
    public const string DEFAULT_LOW_LEVEL_EXCEPTION = "an exception was thrown";
    protected KitException(string? message) : base(GetMessageToShow(message, DEFAULT_LOW_LEVEL_EXCEPTION))
    {
    }

    private KitException()
    {
            
    }

    protected static string? GetMessageToShow(string? message, string? defaultMessage)
    {
        if (message.IsEmpty()) return defaultMessage;
        else return message;
    }
}

public interface IException
{
    abstract static string? DefaultMessage { get; set; }
}