using Practicum.Common;

namespace Practicum.Tasks.Level2;

public class Task21_WeekDays : ITask
{
    public string Title => "Дни недели";
    public string Description => "Определить название дня и является ли он выходным.";
    public string[] Requirements => new[]
    {
        "enum DayOfWeek",
        "IsWeekend и GetRussianName",
        "Показать все семь дней"
    };


    private enum DayOfWeek
    {
        Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday
    }

    public void Run()
    {
        foreach (DayOfWeek day in Enum.GetValues<DayOfWeek>())
            Console.WriteLine(GetRussianName(day) + " — выходной: " + IsWeekend(day));
    }

    private static bool IsWeekend(DayOfWeek day)
    {
        return day == DayOfWeek.Saturday || day == DayOfWeek.Sunday;
    }

    private static string GetRussianName(DayOfWeek day)
    {
        return day switch
        {
            DayOfWeek.Monday => "Понедельник",
            DayOfWeek.Tuesday => "Вторник",
            DayOfWeek.Wednesday => "Среда",
            DayOfWeek.Thursday => "Четверг",
            DayOfWeek.Friday => "Пятница",
            DayOfWeek.Saturday => "Суббота",
            DayOfWeek.Sunday => "Воскресенье",
            _ => "Неизвестно"
        };
    }
}
