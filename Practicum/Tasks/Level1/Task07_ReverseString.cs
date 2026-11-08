using System;
using System.Collections.Generic;
using System.Text;

using Practicum.Common;

namespace Practicum.Tasks.Level1;
public class Task07_ReverseString : ITask
{
    public string Title => "Реверс строки без LINQ";
    public string Description => "Перевернуть введённую строку.";
    public string[] Requirements => new[]
    {
        "Не использовать Array.Reverse и LINQ",
        "Реализовать через цикл for от конца к началу",
        "Пустая строка и строка из одного символа — обрабатываются корректно"
    };

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