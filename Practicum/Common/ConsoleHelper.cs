using System;
using System.Collections.Generic;
using System.Text;

namespace Practicum.Common;

/// <summary>Меню или вспомогательный класс.</summary>
public static class ConsoleHelper
{
    /// <summary>Выводит информацию в консоль.</summary>
    public static void PrintTaskHeader(string number, ITask task)
    {
        Console.WriteLine(new string('=', 50));
        Console.WriteLine($"Задание {number}. {task.Title}");
        Console.WriteLine(new string('-', 50));
        Console.WriteLine("Описание:");
        Console.WriteLine($"  {task.Description}");
        Console.WriteLine();
        Console.WriteLine("Требования:");
        foreach (var r in task.Requirements)
            Console.WriteLine($"  - {r}");
        Console.WriteLine();
        Console.WriteLine("Ожидаемый результат:");
        Console.WriteLine("  " + task.Description);
        Console.WriteLine("Подсказка:");
        if (task.Requirements.Length > 0)
            Console.WriteLine("  " + task.Requirements[0]);
        Console.WriteLine(new string('-', 50));
        Console.WriteLine("[запуск решения...]\n");
    }

    /// <summary>Ожидает ввода.</summary>
    public static void Pause()
    {
        Console.WriteLine("\nНажмите Enter для возврата в меню...");
        Console.ReadLine();
    }
}