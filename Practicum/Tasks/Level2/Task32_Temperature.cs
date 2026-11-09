using System;
using System.Collections.Generic;
using System.Text;

using Practicum.Common;

namespace Practicum.Tasks.Level2;

/// <summary>Задание 32. Свойства с валидацией (Temperature).</summary>
public class Task32_Temperature : ITask
{
    public string Title => "Свойства с валидацией (Temperature)";
    public string Description => "Класс Temperature с валидацией в set.";
    public string[] Requirements => new[]
    {
        "Свойство Celsius с проверкой в set: не ниже −273.15",
        "При некорректном значении — бросать ArgumentOutOfRangeException",
        "Вычисляемое свойство Fahrenheit (только get)",
        "Продемонстрировать корректное и некорректное присваивание"
    };

    public void Run()
    {
        var temp = new Temperature();

        try
        {
            temp.Celsius = 25;
            Console.WriteLine($"Успешно установлено: {temp.Celsius}°C = {temp.Fahrenheit:F1}°F");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        try
        {
            temp.Celsius = -300;
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine($"Ошибка при установке: {ex.Message}");
        }
    }
}

public class Temperature
{
    private double _celsius;

    public double Celsius
    {
        get => _celsius;
        set
        {
            if (value < -273.15)
                throw new ArgumentOutOfRangeException(nameof(value), "Температура не может быть ниже абсолютного нуля (-273.15°C)");
            _celsius = value;
        }
    }

    public double Fahrenheit => _celsius * 9 / 5 + 32;
}