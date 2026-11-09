using System;
using System.Collections.Generic;
using System.Text;

using Practicum.Common;

namespace Practicum.Tasks.Level2;

/// <summary>Задание 29. Паттерн «Фабрика» (уведомления).</summary>
public class Task29_NotificationFactory : ITask
{
    public string Title => "Паттерн «Фабрика» (уведомления)";
    public string Description => "Реализовать фабрику уведомлений.";
    public string[] Requirements => new[]
    {
        "Интерфейс INotification с методом Send(string message)",
        "Реализации: EmailNotification, SmsNotification, PushNotification",
        "NotificationFactory.Create(NotificationType type) — возвращает нужную реализацию",
        "enum NotificationType { Email, Sms, Push }",
        "Продемонстрировать создание и отправку через фабрику"
    };

    public void Run()
    {
        var types = new[] { NotificationType.Email, NotificationType.Sms, NotificationType.Push };

        foreach (var type in types)
        {
            INotification notification = NotificationFactory.Create(type);
            notification.Send("Тестовое сообщение");
        }
    }
}

public enum NotificationType { Email, Sms, Push }

public interface INotification
{
    void Send(string message);
}

public class EmailNotification : INotification
{
    public void Send(string message) => Console.WriteLine($"Email отправлен: {message}");
}

public class SmsNotification : INotification
{
    public void Send(string message) => Console.WriteLine($"SMS отправлено: {message}");
}

public class PushNotification : INotification
{
    public void Send(string message) => Console.WriteLine($"Push отправлен: {message}");
}

public static class NotificationFactory
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