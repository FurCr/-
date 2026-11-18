using System;
using System.Collections.Generic;
using System.Text;

using Practicum.Common;

namespace Practicum.Tasks.Level1;

/// <summary>Задание №2.</summary>
public class Task02_Primitives : ITask
{
    /// <summary>Название задания.</summary>
    public string Title => "Переменные примитивных типов";
    /// <summary>Описание задания.</summary>
    public string Description => "Объявить переменные всех примитивных типов и вывести их значения и типы.";
    /// <summary>Условия задания.</summary>
    public string[] Requirements => new[]
    {
        "Объявить минимум: int, long, double, float, decimal, bool, char, string",
        "Для каждой переменной вывести значение и GetType().Name",
        "decimal — с суффиксом m, float — с f"
    };

    /// <summary>Ожидаемый результат.</summary>
    public string ExpectedResult => "Показаны значения всех типов и их названия.";
    /// <summary>Подсказка.</summary>
    public string Hint => "Для float пишем f, для decimal — m.";

    /// <summary>Запускает задание.</summary>
    public void Run()
    {
        int i = 42;
        long l = 1234567890123L;
        double d = 3.14159;
        float f = 2.71f;
        decimal m = 199.99m;
        bool b = true;
        char c = 'A';
        string s = "Привет";

        Console.WriteLine($"int i = {i} ({i.GetType().Name})");
        Console.WriteLine($"long l = {l} ({l.GetType().Name})");
        Console.WriteLine($"double d = {d} ({d.GetType().Name})");
        Console.WriteLine($"float f = {f} ({f.GetType().Name})");
        Console.WriteLine($"decimal m = {m} ({m.GetType().Name})");
        Console.WriteLine($"bool b = {b} ({b.GetType().Name})");
        Console.WriteLine($"char c = {c} ({c.GetType().Name})");
        Console.WriteLine($"string s = {s} ({s.GetType().Name})");
    }
}
