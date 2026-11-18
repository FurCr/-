using Practicum.Common;

namespace Practicum.Tasks.Level2;

/// <summary>Задание №20.</summary>
public class Task20_Generics : ITask
{
    /// <summary>Название задания.</summary>
    public string Title => "Обобщённые методы";
    /// <summary>Описание задания.</summary>
    public string Description => "Обмен значений и поиск большего для разных типов.";
    /// <summary>Условия задания.</summary>
    public string[] Requirements => new[]
    {
        "Swap<T> с ref",
        "Max<T> с IComparable<T>",
        "Примеры для int, string, double"
    };


    /// <summary>Ожидаемый результат.</summary>
    public string ExpectedResult => "Swap и Max работают для трёх типов.";
    /// <summary>Подсказка.</summary>
    public string Hint => "Для Max можно вызвать CompareTo.";

    /// <summary>Запускает задание.</summary>
    public void Run()
    {
        int a = 4, b = 9;
        Swap(ref a, ref b);
        Console.WriteLine("int после обмена: " + a + ", " + b + "; максимум: " + Max(a, b));

        string first = "арбуз", second = "банан";
        Swap(ref first, ref second);
        Console.WriteLine("string после обмена: " + first + ", " + second + "; максимум: " + Max(first, second));

        double x = 1.5, y = 2.8;
        Swap(ref x, ref y);
        Console.WriteLine("double после обмена: " + x + ", " + y + "; максимум: " + Max(x, y));
    }

    private static void Swap<T>(ref T a, ref T b)
    {
        T temp = a;
        a = b;
        b = temp;
    }

    private static T Max<T>(T a, T b) where T : IComparable<T>
    {
        return a.CompareTo(b) >= 0 ? a : b;
    }
}
