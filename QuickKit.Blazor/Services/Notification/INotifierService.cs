using Radzen;

namespace QuickKit.Blazor.Services.Notification
{
    public interface INotifierService
    {
        void Notify(NotificationSeverity severity = NotificationSeverity.Info, string summary = "", string detail = "", double duration = 3000, Action<NotificationMessage> click = null, bool closeOnClick = false, object? payload = null, Action<NotificationMessage>? close = null);
        void Notify(NotificationMessage message);
    }
}