using System;
using System.Collections.Generic;
using System.Text;

namespace Practicum.Common;

public static class ConsoleHelper
{
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
        Console.WriteLine(new string('-', 50));
        Console.WriteLine("[запуск решения...]\n");
    }

    public static void Pause()
    {
        Console.WriteLine("\nНажмите Enter для возврата в меню...");
        Console.ReadLine();
    }
}