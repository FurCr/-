using Practicum.Common;

namespace Practicum.Tasks.Level2;

/// <summary>Задание №22.</summary>
public class Task22_Params : ITask
{
    /// <summary>Название задания.</summary>
    public string Title => "params и перегрузка";
    /// <summary>Описание задания.</summary>
    public string Description => "Методы для подсчёта суммы чисел.";
    /// <summary>Условия задания.</summary>
    public string[] Requirements => new[]
    {
        "Sum(params int[])",
        "Перегрузка для списка чисел",
        "Примеры с числами, массивом и пустым вызовом"
    };


    /// <summary>Ожидаемый результат.</summary>
    public string ExpectedResult => "Сумма верная для чисел, массива и пустого вызова.";
    /// <summary>Подсказка.</summary>
    public string Hint => "Проверь сумму чисел, массива и пустой вызов.";

    /// <summary>Запускает задание.</summary>
    public void Run()
    {
        int[] values = { 1, 2, 3 };
        Console.WriteLine("Числа: " + Sum(1, 2, 3));
        Console.WriteLine("Массив: " + Sum(values));
        Console.WriteLine("Список: " + Sum(new List<int> { 1, 2, 3 }));
        Console.WriteLine("Без чисел: " + Sum());
    }

    private static int Sum(params int[] numbers)
    {
        int result = 0;
        foreach (int number in numbers)
            result += number;
        return result;
    }

    // params int[] и int[] — одна сигнатура, поэтому перегрузка принимает List<int>.
    private static int Sum(List<int> numbers)
    {
        int result = 0;
        foreach (int number in numbers)
            result += number;
        return result;
    }
}
