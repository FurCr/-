using System;
using System.Collections.Generic;
using System.Text;

using Practicum.Common;

namespace Practicum.Tasks.Level1;
public class Task04_EvenOdd : ITask
{
    public string Title => "Чётность числа (два способа)";
    public string Description => "Определить, чётное ли введённое число.";
    public string[] Requirements => new[]
    {
        "Способ 1: через % 2 == 0",
        "Способ 2: через тернарный оператор ? :",
        "Оба способа реализовать отдельными методами",
        "Вывести результат обоих способов"
    };

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