using System;
using System.Collections.Generic;
using System.Text;

using Practicum.Common;

namespace Practicum.Tasks.Level1;
/// <summary>Задание №4.</summary>
public class Task04_EvenOdd : ITask
{
    /// <summary>Название задания.</summary>
    public string Title => "Чётность числа (два способа)";
    /// <summary>Описание задания.</summary>
    public string Description => "Определить, чётное ли введённое число.";
    /// <summary>Условия задания.</summary>
    public string[] Requirements => new[]
    {
        "Способ 1: через % 2 == 0",
        "Способ 2: через тернарный оператор ? :",
        "Оба способа реализовать отдельными методами",
        "Вывести результат обоих способов"
    };

    /// <summary>Ожидаемый результат.</summary>
    public string ExpectedResult => "Оба способа правильно определяют чётность.";
    /// <summary>Подсказка.</summary>
    public string Hint => "Оба метода должны вернуть результат.";

    /// <summary>Запускает задание.</summary>
    public void Run()
    {
        Console.Write("Введите целое число: ");
        if (!int.TryParse(Console.ReadLine(), out int n))
        {
            Console.WriteLine("Ошибка ввода.");
            return;
        }
        Console.WriteLine($"Способ 1 (остаток): {IsEvenModulo(n)}");
        Console.WriteLine($"Способ 2 (тернарный): {IsEvenTernary(n)}");
    }
    private bool IsEvenModulo(int n) => n % 2 == 0;

    private bool IsEvenTernary(int n) => n % 2 == 0 ? true : false;
}