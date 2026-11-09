using System;
using System.Collections.Generic;
using System.Text;

using Practicum.Common;

namespace Practicum.Tasks.Level2;

/// <summary>Задание 18. TryParse vs try/catch.</summary>
public class Task18_TryParseVsTryCatch : ITask
{
    public string Title => "TryParse vs try/catch";
    public string Description => "Сравнить два способа обработки некорректного ввода числа.";
    public string[] Requirements => new[]
    {
        "Способ 1: int.TryParse — вернуть bool + значение через out",
        "Способ 2: int.Parse внутри try/catch — ловить FormatException",
        "Оба оформить отдельными методами",
        "Продемонстрировать на корректном и некорректном вводе"
    };

    public void Run()
    {
        Console.WriteLine("--- Тест с корректным числом '123' ---");
        TestParsing("123");

        Console.WriteLine("\n--- Тест с некорректным числом 'abc' ---");
        TestParsing("abc");
    }

    private void TestParsing(string input)
    {
        Console.WriteLine($"Ввод: \"{input}\"");

        if (int.TryParse(input, out int val1))
            Console.WriteLine($"TryParse: Успешно, число {val1}");
        else
            Console.WriteLine("TryParse: Ошибка, это не число");

        try
        {
            int val2 = int.Parse(input);
            Console.WriteLine($"Parse (try/catch): Успешно, число {val2}");
        }
        catch (FormatException)
        {
            Console.WriteLine("Parse (try/catch): Поймали FormatException");
        }
    }
}