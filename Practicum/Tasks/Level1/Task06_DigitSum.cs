using Practicum.Common;

namespace Practicum.Tasks.Level1;

/// <summary>Задание №6.</summary>
public class Task06_DigitSum : ITask
{
    /// <summary>Название задания.</summary>
    public string Title => "Сумма цифр числа (строка + арифметика)";
    /// <summary>Описание задания.</summary>
    public string Description => "Найти сумму цифр введённого числа (например, 1234 → 10).";
    /// <summary>Условия задания.</summary>
    public string[] Requirements => new[]
    {
        "Способ 1 (строка): число → ToString() → пройти по символам",
        "Способ 2 (арифметика): цикл while (n > 0)",
        "Оба способа оформить отдельными методами",
        "Отрицательные числа — брать модуль"
    };

    /// <summary>Запускает задание.</summary>
    public void Run()
    {
        Console.Write("Введите число: ");
        if (!long.TryParse(Console.ReadLine(), out long n))
        {
            Console.WriteLine("Ошибка ввода.");
            return;
        }

        Console.WriteLine("Способ 1 (строка): " + SumByString(n));
        Console.WriteLine("Способ 2 (арифметика): " + SumByArithmetic(n));
    }

    private int SumByString(long n)
    {
        string text = n.ToString().TrimStart('-');
        int sum = 0;
        foreach (char digit in text)
            sum += int.Parse(digit.ToString());
        return sum;
    }

    private int SumByArithmetic(long n)
    {
        int sum = 0;
        while (n != 0)
        {
            sum += (int)Math.Abs(n % 10);
            n /= 10;
        }
        return sum;
    }
}
