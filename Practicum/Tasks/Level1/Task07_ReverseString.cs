using System;
using System.Collections.Generic;
using System.Text;

using Practicum.Common;

namespace Practicum.Tasks.Level1;
/// <summary>Задание №7.</summary>
public class Task07_ReverseString : ITask
{
    /// <summary>Название задания.</summary>
    public string Title => "Реверс строки без LINQ";
    /// <summary>Описание задания.</summary>
    public string Description => "Перевернуть введённую строку.";
    /// <summary>Условия задания.</summary>
    public string[] Requirements => new[]
    {
        "Не использовать Array.Reverse и LINQ",
        "Реализовать через цикл for от конца к началу",
        "Пустая строка и строка из одного символа — обрабатываются корректно"
    };

    /// <summary>Ожидаемый результат.</summary>
    public string ExpectedResult => "Строка перевёрнута, даже если она пустая.";
    /// <summary>Подсказка.</summary>
    public string Hint => "Можно добавлять символы в результат по одному.";

    /// <summary>Запускает задание.</summary>
    public void Run()
    {
        Console.Write("Введите строку: ");
        string input = Console.ReadLine() ?? "";
        Console.WriteLine($"Результат: {Reverse(input)}");
    }

    private string Reverse(string s)
    {
        char[] result = new char[s.Length];

        for (int i = 0; i < s.Length; i++)
        {
            result[i] = s[s.Length - 1 - i];
        }
        return new string(result);
    }
}