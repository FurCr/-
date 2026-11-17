using Practicum.Common;

namespace Practicum.Tasks.Level2;

public class Task23_Nullable : ITask
{
    public string Title => "Nullable-типы";
    public string Description => "Показать ??, ?. и проверку nullable.";
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
        public string Name { get; set; } = "";
    }
}
