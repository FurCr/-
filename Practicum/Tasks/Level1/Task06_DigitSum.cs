using System;
using System.Collections.Generic;
using System.Text;

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

        Console.WriteLine($"Способ 1 (строка): {SumByString(n)}");
        Console.WriteLine($"Способ 2 (арифметика): {SumByArithmetic(n)}");
    }

    private int SumByString(long n)
    {
        string s = Math.Abs(n).ToString(); 
        int sum = 0;
        foreach (char c in s)
            sum += int.Parse(c.ToString());
        return sum;
    }

    private int SumByArithmetic(long n)
    {
        n = Math.Abs(n);
        int sum = 0;
        while (n > 0)
        {
            sum += (int)(n % 10); 
            n /= 10;              
        }
        return sum;
    }
}