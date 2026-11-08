using System;
using System.Collections.Generic;
using System.Text;
using Practicum.Common;

namespace Practicum.Tasks.Level1;

public class Task01_HelloWorld : ITask
{
    public string Title => "Hello, World + текущая дата";
    public string Description => "Вывести приветствие и текущую дату.";
    public string[] Requirements => new[]
    {
        "Использовать Console.WriteLine",
        "Дату получить через DateTime.Now, отформатировать как dd.MM.yyyy",
        "Вывести две строки: приветствие и дату"
    };

    public void Run()
    {
        Console.WriteLine("Hello, World!");
        Console.WriteLine(DateTime.Now.ToString("dd.MM.yyyy"));
    }
}
