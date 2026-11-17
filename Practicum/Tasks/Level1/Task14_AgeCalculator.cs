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
        if (!DateTime.TryParse(Console.ReadLine(), out DateTime birth))
        {
            Console.WriteLine("Ошибка: неверная дата.");
            return;
        }

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
        while (date.AddMonths(1) <= today)
        {
            date = date.AddMonths(1);
            months++;
        }

        int days = (today - date).Days;
        Console.WriteLine("Возраст: " + years + " лет, " + months + " месяцев, " + days + " дней");
    }
}
