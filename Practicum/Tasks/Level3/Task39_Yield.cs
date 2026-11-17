using Practicum.Common;

namespace Practicum.Tasks.Level3;

/// <summary>Задание №39.</summary>
public class Task39_Yield : ITask
{
    /// <summary>Название задания.</summary>
    public string Title => "yield return";
    /// <summary>Описание задания.</summary>
    public string Description => "Получить чётные числа без создания списка.";
    /// <summary>Условия задания.</summary>
    public string[] Requirements => new[]
    {
        "Метод IEnumerable<int> GetEvenNumbers",
        "yield return",
        "Показать ленивый вывод"
    };

    /// <summary>Запускает задание.</summary>
    public void Run()
    {
        Console.WriteLine("Создаём перечисление.");
        IEnumerable<int> numbers = GetEvenNumbers(12);
        Console.WriteLine("Начинаем foreach:");
        foreach (int number in numbers)
            Console.WriteLine("Получили: " + number);
    }

    private static IEnumerable<int> GetEvenNumbers(int max)
    {
        for (int i = 2; i <= max; i += 2)
        {
            Console.WriteLine("Генератор: " + i);
            yield return i;
        }
    }
}
