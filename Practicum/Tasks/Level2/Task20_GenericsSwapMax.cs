using System;
using System.Collections.Generic;
using System.Text;

using Practicum.Common;

namespace Practicum.Tasks.Level2;

/// <summary>Задание 20. Обобщения: Swap<T>, Max<T> с IComparable<T>.</summary>
public class Task20_GenericsSwapMax : ITask
{
    public string Title => "Обобщения: Swap<T>, Max<T> с IComparable<T>";
    public string Description => "Написать обобщённые методы.";
    public string[] Requirements => new[]
    {
        "Swap<T>(ref T a, ref T b) — меняет значения местами",
        "Max<T>(T a, T b) where T : IComparable<T> — возвращает большее",
        "Продемонстрировать на int, string, double",
        "Swap — без ограничений, Max — с ограничением"
    };

    public void Run()
    {
        int a = 5, b = 10;
        Console.WriteLine($"До Swap: a={a}, b={b}");
        Swap(ref a, ref b);
        Console.WriteLine($"После Swap: a={a}, b={b}");
        Console.WriteLine($"Max(5, 10): {Max(5, 10)}");

        string s1 = "apple", s2 = "banana";
        Console.WriteLine($"\nДо Swap: s1={s1}, s2={s2}");
        Swap(ref s1, ref s2);
        Console.WriteLine($"После Swap: s1={s1}, s2={s2}");
        Console.WriteLine($"Max(apple, banana): {Max("apple", "banana")}");

        double d1 = 3.14, d2 = 2.71;
        Console.WriteLine($"\nДо Swap: d1={d1}, d2={d2}");
        Swap(ref d1, ref d2);
        Console.WriteLine($"После Swap: d1={d1}, d2={d2}");
        Console.WriteLine($"Max(3.14, 2.71): {Max(3.14, 2.71)}");
    }

    private void Swap<T>(ref T a, ref T b)
    {
        T temp = a;
        a = b;
        b = temp;
    }

    private T Max<T>(T a, T b) where T : IComparable<T>
    {
        return a.CompareTo(b) > 0 ? a : b;
    }
}