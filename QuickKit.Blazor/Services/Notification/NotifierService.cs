using Radzen;

namespace QuickKit.Blazor.Services.Notification;

public class NotifierService(NotificationService notificationService) : INotifierService
{
    public void Notify(NotificationMessage message)
    {
        notificationService.Notify(message);
    }

    public void Notify(NotificationSeverity severity = NotificationSeverity.Info, string summary = "",
                       string detail = "", double duration = 3000.0, Action<NotificationMessage> click = null,
                       bool closeOnClick = false, object? payload = null, Action<NotificationMessage>? close = null)
    {
        notificationService.Notify(severity, summary, detail, duration, click, closeOnClick, payload, close);
    }
}
