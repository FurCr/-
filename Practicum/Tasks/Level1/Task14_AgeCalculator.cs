using System;
using System.Collections.Generic;
using System.Text;

using Practicum.Common;

namespace Practicum.Tasks.Level1;
public class Task14_AgeCalculator : ITask
{
    public string Title => "Возраст по дате рождения";
    public string Description => "По дате рождения вычислить точный возраст в годах, месяцах и днях.";
    public string[] Requirements => new[]
    {
        "Ввод даты через DateTime.TryParse (или TryParseExact)",
        "Учесть, что день рождения в этом году мог ещё не наступить",
        "Вывести «X лет, Y месяцев, Z дней»",
        "Некорректная дата — сообщение об ошибке, не падать"
    };

    public void Run()
    {
        Console.Write("Введите дату рождения (например, 15.05.1990): ");
        string input = Console.ReadLine() ?? "";

        if (!DateTime.TryParse(input, out DateTime birthDate))
        {
            Console.WriteLine("Ошибка: неверный формат даты.");
            return;
        }

        DateTime today = DateTime.Today;
        if (birthDate > today)
        {
            Console.WriteLine("Ошибка: дата рождения не может быть в будущем.");
            return;
        }

        int years = today.Year - birthDate.Year;
        int months = today.Month - birthDate.Month;
        int days = today.Day - birthDate.Day;

        if (days < 0)
        {
            months--;
       
            int prevMonth = today.Month == 1 ? 12 : today.Month - 1;
            int prevYear = today.Month == 1 ? today.Year - 1 : today.Year;
            days += DateTime.DaysInMonth(prevYear, prevMonth);
        }

        if (months < 0)
        {
            years--;
            months += 12;
        }

        Console.WriteLine($"Возраст: {years} лет, {months} месяцев, {days} дней");
    }
}