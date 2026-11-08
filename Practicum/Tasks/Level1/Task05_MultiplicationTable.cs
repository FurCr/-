using System;
using System.Collections.Generic;
using System.Text;

using Practicum.Common;

namespace Practicum.Tasks.Level1;

public class Task05_MultiplicationTable : ITask
{
    public string Title => "Таблица умножения 10×10";
    public string Description => "Вывести таблицу умножения 10×10.";
    public string[] Requirements => new[]
    {
        "Использовать вложенные циклы for",
        "Выровнять столбцы",
        "Заголовки строк/столбцов — не обязательны, но приветствуются"
    };

    public void Run()
    {
        Console.Write("    "); 
        for (int j = 1; j <= 10; j++)
        {
            Console.Write($"{j,4}"); 
        }
        Console.WriteLine();
        for (int i = 1; i <= 10; i++)
        {
            Console.Write($"{i,3} "); 

            for (int j = 1; j <= 10; j++)
            {
                Console.Write($"{i * j,4}"); 
            }
            Console.WriteLine();
        }
    }
}