using System;
using System.Collections.Generic;
using System.Text;

using Practicum.Common;

namespace Practicum.Tasks.Level1;

/// <summary>Задание №3.</summary>
public class Task03_Calculator : ITask
{
    /// <summary>Название задания.</summary>
    public string Title => "Калькулятор с делением на ноль";
    /// <summary>Описание задания.</summary>
    public string Description => "Принимает два числа и оператор (+, -, *, /), выводит результат. Обработать деление на ноль.";
    /// <summary>Условия задания.</summary>
    public string[] Requirements => new[]
    {
        "Использовать switch для оператора",
        "При делении на ноль вывести сообщение об ошибке, не ронять приложение",
        "Некорректный оператор — вывести «Неизвестная операция»",
        "Ввод чисел — через double.Parse или TryParse"
    };

    /// <summary>Ожидаемый результат.</summary>
    public string ExpectedResult => "Все четыре действия работают, деление на ноль обработано.";
    /// <summary>Подсказка.</summary>
    public string Hint => "Используй switch и TryParse.";

    /// <summary>Запускает задание.</summary>
    public void Run()
    {
        Console.Write("Введите первое число: ");
        if (!double.TryParse(Console.ReadLine(), out double a))
        {
            Console.WriteLine("Ошибка: неверное число.");
            return;
        }

        Console.Write("Введите второе число: ");
        if (!double.TryParse(Console.ReadLine(), out double b))
        {
            Console.WriteLine("Ошибка: неверное число.");
            return;
        }

        Console.Write("Введите оператор (+, -, *, /): ");
        string op = Console.ReadLine() ?? "";

        switch (op)
        {
            case "+": Console.WriteLine($"Результат: {a + b}"); break;
            case "-": Console.WriteLine($"Результат: {a - b}"); break;
            case "*": Console.WriteLine($"Результат: {a * b}"); break;
            case "/":
                if (b == 0) Console.WriteLine("Ошибка: деление на ноль невозможно.");
                else Console.WriteLine($"Результат: {a / b}");
                break;
            default:
                Console.WriteLine("Неизвестная операция");
                break;
        }
    }
}