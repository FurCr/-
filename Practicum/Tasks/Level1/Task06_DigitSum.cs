using Practicum.Common;

namespace Practicum.Tasks.Level1;

public class Task06_DigitSum : ITask
{
    public string Title => "Сумма цифр числа (строка + арифметика)";
    public string Description => "Найти сумму цифр введённого числа (например, 1234 → 10).";
    public string[] Requirements => new[]
    {
        "Способ 1 (строка): число → ToString() → пройти по символам",
        "Способ 2 (арифметика): цикл while (n > 0)",
        "Оба способа оформить отдельными методами",
        "Отрицательные числа — брать модуль"
    };

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
