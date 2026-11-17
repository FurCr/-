using Practicum.Common;

namespace Practicum.Tasks.Level3;

/// <summary>Задание №36.</summary>
public class Task36_Duplicates : ITask
{
    /// <summary>Название задания.</summary>
    public string Title => "Повторяющиеся числа";
    /// <summary>Описание задания.</summary>
    public string Description => "Найти дубликаты двумя способами.";
    /// <summary>Условия задания.</summary>
    public string[] Requirements => new[]
    {
        "Использовать HashSet и Contains",
        "Использовать GroupBy и Where",
        "Сравнить результаты"
    };

    /// <summary>Запускает задание.</summary>
    public void Run()
    {
        List<int> numbers = new List<int> { 2, 4, 6, 2, 7, 4, 8, 2, 9, 8 };
        List<int> first = FindWithSet(numbers);
        List<int> second = FindWithLinq(numbers);

        Console.WriteLine("HashSet: " + string.Join(", ", first));
        Console.WriteLine("LINQ: " + string.Join(", ", second));
        Console.WriteLine("Одинаковые результаты: " + first.SequenceEqual(second));
    }

    private static List<int> FindWithSet(List<int> numbers)
    {
        HashSet<int> seen = new HashSet<int>();
        HashSet<int> duplicate = new HashSet<int>();
        foreach (int number in numbers)
        {
            if (seen.Contains(number))
                duplicate.Add(number);
            else
                seen.Add(number);
        }
        return duplicate.OrderBy(x => x).ToList();
    }

    private static List<int> FindWithLinq(List<int> numbers)
    {
        return numbers.GroupBy(x => x)
            .Where(group => group.Count() > 1)
            .Select(group => group.Key)
            .OrderBy(x => x)
            .ToList();
    }
}
