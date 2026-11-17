using Practicum.Common;

namespace Practicum.Tasks.Level2;

public class Task29_Notifications : ITask
{
    public string Title => "Фабрика уведомлений";
    public string Description => "Создать уведомления разных видов через фабрику.";
    public string[] Requirements => new[]
    {
        "INotification с Send",
        "Email, Sms, Push",
        "NotificationFactory.Create"
    };

    public void Run()
    {
        foreach (NotificationType type in Enum.GetValues<NotificationType>())
        {
            INotification notification = NotificationFactory.Create(type);
            notification.Send("Привет!");
        }
    }

    private enum NotificationType
    {
        Email, Sms, Push
    }

    private interface INotification
    {
        void Send(string message);
    }

    private class EmailNotification : INotification
    {
        public void Send(string message) => Console.WriteLine("Email: " + message);
    }

    private class SmsNotification : INotification
    {
        public void Send(string message) => Console.WriteLine("SMS: " + message);
    }

    private class PushNotification : INotification
    {
        public void Send(string message) => Console.WriteLine("Push: " + message);
    }

    private static class NotificationFactory
    {
        public static INotification Create(NotificationType type)
        {
            return type switch
            {
                NotificationType.Email => new EmailNotification(),
                NotificationType.Sms => new SmsNotification(),
                NotificationType.Push => new PushNotification(),
                _ => throw new ArgumentException("Неизвестный тип уведомления")
            };
        }
    }
}
