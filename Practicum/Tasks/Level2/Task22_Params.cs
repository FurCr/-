using Practicum.Common;

namespace Practicum.Tasks.Level2;

public class Task22_Params : ITask
{
    public string Title => "params и перегрузка";
    public string Description => "Методы для подсчёта суммы чисел.";
    public string[] Requirements => new[]
    {
        "Sum(params int[])",
        "Перегрузка для последовательности чисел",
        "Примеры с числами, массивом и пустым вызовом"
    };


    public void Run()
    {
        int[] values = { 1, 2, 3 };
        Console.WriteLine("Числа: " + Sum(1, 2, 3));
        Console.WriteLine("Массив: " + Sum(values));
        Console.WriteLine("Перегрузка: " + Sum((IEnumerable<int>)values));
        Console.WriteLine("Без чисел: " + Sum());
    }

    private static int Sum(params int[] numbers)
    {
        int result = 0;
        foreach (int number in numbers)
            result += number;
        return result;
    }

    // params int[] и int[] имеют одну сигнатуру, поэтому перегрузка принимает IEnumerable<int>.
    private static int Sum(IEnumerable<int> numbers)
    {
        int result = 0;
        foreach (int number in numbers)
            result += number;
        return result;
    }
}
