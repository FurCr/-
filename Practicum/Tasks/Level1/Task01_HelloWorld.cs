using System;
using System.Collections.Generic;
using System.Text;
using Practicum.Common;

namespace Practicum.Tasks.Level1;

/// <summary>Задание №1.</summary>
public class Task01_HelloWorld : ITask
{
    /// <summary>Название задания.</summary>
    public string Title => "Hello, World + текущая дата";
    /// <summary>Описание задания.</summary>
    public string Description => "Вывести приветствие и текущую дату.";
    /// <summary>Условия задания.</summary>
    public string[] Requirements => new[]
    {
        "Использовать Console.WriteLine",
        "Дату получить через DateTime.Now, отформатировать как dd.MM.yyyy",
        "Вывести две строки: приветствие и дату"
    };

    /// <summary>Запускает задание.</summary>
    public void Run()
    {
        Console.WriteLine("Hello, World!");
        Console.WriteLine(DateTime.Now.ToString("dd.MM.yyyy"));
    }
}
