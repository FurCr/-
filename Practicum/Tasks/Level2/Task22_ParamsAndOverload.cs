using System;
using System.Collections.Generic;
using System.Text;

using Practicum.Common;

namespace Practicum.Tasks.Level2;

/// <summary>Задание 22. params-метод + перегрузка.</summary>
public class Task22_ParamsAndOverload : ITask
{
    public string Title => "params-метод + перегрузка";
    public string Description => "Написать метод суммы с params и его перегрузку.";
    public string[] Requirements => new[]
    {
        "Sum(params int[] numbers) — сумма произвольного числа чисел",
        "Перегрузка Sum(int[] numbers) — та же логика для массива",
        "Продемонстрировать: Sum(1, 2, 3), Sum(new[] {1, 2, 3}), Sum()",
        "Пустой вызов — вернуть 0"
    };

    public void Run()
    {
     
        Console.WriteLine($"Sum(1, 2, 3) = {Sum(1, 2, 3)}");
        Console.WriteLine($"Sum(new[] {{1, 2, 3}}) = {Sum(new int[] { 1, 2, 3 })}");
        Console.WriteLine($"Sum() = {Sum()}");
        var list = new System.Collections.Generic.List<int> { 5, 10, 15 };
        Console.WriteLine($"Sum(IEnumerable) = {SumCollection(list)}");
    }
    private int Sum(params int[] numbers)
    {
        int total = 0;
        foreach (var n in numbers) total += n;
        return total;
    }

    private int SumCollection(System.Collections.Generic.IEnumerable<int> numbers)
    {
        int total = 0;
        foreach (var n in numbers) total += n;
        return total;
    }
}