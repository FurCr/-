using Practicum.Common;

namespace Practicum.Tasks.Level1;

/// <summary>Задание №14.</summary>
public class Task14_AgeCalculator : ITask
{
    /// <summary>Название задания.</summary>
    public string Title => "Возраст по дате рождения";
    /// <summary>Описание задания.</summary>
    public string Description => "По дате рождения вычислить точный возраст в годах, месяцах и днях.";
    /// <summary>Условия задания.</summary>
    public string[] Requirements => new[]
    {
        "Ввод даты через DateTime.TryParse (или TryParseExact)",
        "Учесть, что день рождения в этом году мог ещё не наступить",
        "Вывести «X лет, Y месяцев, Z дней»",
        "Некорректная дата — сообщение об ошибке, не падать"
    };

    /// <summary>Ожидаемый результат.</summary>
    public string ExpectedResult => "Возраст показан в годах, месяцах и днях.";
    /// <summary>Подсказка.</summary>
    public string Hint => "Проверяй, что дата не в будущем.";

    /// <summary>Запускает задание.</summary>
    public void Run()
    {
        Console.Write("Введите дату рождения (например, 15.05.1990): ");
        if (!DateTime.TryParse(Console.ReadLine(), out DateTime birth))
        {
            Console.WriteLine("Ошибка: неверная дата.");
            return;
        }

        birth = birth.Date;
        DateTime today = DateTime.Today;
        if (birth.Date > today)
        {
            Console.WriteLine("Ошибка: дата рождения не может быть в будущем.");
            return;
        }

        int years = today.Year - birth.Year;
        if (birth.AddYears(years) > today)
            years--;

        DateTime date = birth.AddYears(years);
        int months = 0;
        while (date.AddMonths(months + 1) <= today)
            months++;

        int days = (today - date.AddMonths(months)).Days;
        Console.WriteLine("Возраст: " + years + " лет, " + months + " месяцев, " + days + " дней");
    }
}
