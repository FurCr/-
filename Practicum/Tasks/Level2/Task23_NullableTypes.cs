using System;
using System.Collections.Generic;
using System.Text;

using Practicum.Common;

namespace Practicum.Tasks.Level2;


public class Task23_NullableTypes : ITask
{
    public string Title => "Nullable-типы, ??, ?.";
    public string Description => "Продемонстрировать работу с nullable.";
    public string[] Requirements => new[]
    {
        "Метод int? FindValue(string key) — возвращает null, если ключа нет",
        "Использовать ?? для значения по умолчанию",
        "Использовать ?. для безопасного доступа к свойству объекта, который может быть null",
        "Использовать HasValue / Value с проверкой",
        "Продемонстрировать на примере с найденным и ненайденным ключом"
    };

    public void Run()
    {
        var dict = new Dictionary<string, string>
        {
            { "name", "Иван" }
        };

        Console.WriteLine("Ищем 'name':");
        var val1 = dict.TryGetValue("name", out var res1) ? res1 : null;
        Console.WriteLine($"Длина строки: {val1?.Length ?? 0}");

        Console.WriteLine("\nИщем 'age':");
        var val2 = dict.TryGetValue("age", out var res2) ? res2 : null;
        Console.WriteLine($"Длина строки: {val2?.Length ?? 0}");

        Console.WriteLine("\nПоиск числа:");
        int? num = FindValue("key1");
        Console.WriteLine($"Результат: {num ?? -1}");

        num = FindValue("key2");
        if (num.HasValue)
            Console.WriteLine($"Нашли: {num.Value}");
        else
            Console.WriteLine("Не нашли");
    }

    private int? FindValue(string key)
    {
        if (key == "key1") return 100;
        return null;
    }
}