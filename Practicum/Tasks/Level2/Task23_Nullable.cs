using Practicum.Common;

namespace Practicum.Tasks.Level2;

/// <summary>Задание №23.</summary>
public class Task23_Nullable : ITask
{
    /// <summary>Название задания.</summary>
    public string Title => "Nullable-типы";
    /// <summary>Описание задания.</summary>
    public string Description => "Показать ??, ?. и проверку nullable.";
    /// <summary>Условия задания.</summary>
    public string[] Requirements => new[]
    {
        "FindValue возвращает int?",
        "Использовать ??, ?. и HasValue/Value",
        "Найденный и ненайденный ключ"
    };


    private static Dictionary<string, int> numbers = new Dictionary<string, int>
    {
        { "one", 10 }, { "two", 20 }
    };

    /// <summary>Запускает задание.</summary>
    public void Run()
    {
        int? found = FindValue("one");
        int? missing = FindValue("three");

        if (found.HasValue)
            Console.WriteLine("Найдено: " + found.Value);

        Console.WriteLine("Нет ключа: " + (missing ?? 0));

        Student? student = null;
        Console.WriteLine("Имя: " + (student?.Name ?? "не указано"));
        student = new Student { Name = "Миша" };
        Console.WriteLine("Имя: " + (student?.Name ?? "не указано"));
    }

    private static int? FindValue(string key)
    {
        if (numbers.TryGetValue(key, out int value))
            return value;
        return null;
    }

    private class Student
    {
        /// <summary>Выполняет действие.</summary>
        public string Name { get; set; } = "";
    }
}
