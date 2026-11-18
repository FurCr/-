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

    /// <summary>Ожидаемый результат.</summary>
    public string ExpectedResult => "Чётные числа выводятся по одному.";
    /// <summary>Подсказка.</summary>
    public string Hint => "Код внутри генератора выполняется при foreach.";

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
        for (long i = 2; i <= max; i += 2)
        {
            Console.WriteLine("Генератор: " + i);
            yield return (int)i;
        }
    }
}
