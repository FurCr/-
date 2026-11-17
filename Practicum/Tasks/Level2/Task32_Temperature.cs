using Practicum.Common;

namespace Practicum.Tasks.Level2;

/// <summary>Задание №32.</summary>
public class Task32_Temperature : ITask
{
    /// <summary>Название задания.</summary>
    public string Title => "Свойства с проверкой";
    /// <summary>Описание задания.</summary>
    public string Description => "Проверить температуру и перевести в Фаренгейты.";
    /// <summary>Условия задания.</summary>
    public string[] Requirements => new[]
    {
        "Celsius не ниже -273.15",
        "ArgumentOutOfRangeException",
        "Вычисляемое Fahrenheit"
    };

    /// <summary>Запускает задание.</summary>
    public void Run()
    {
        Temperature temperature = new Temperature();
        temperature.Celsius = 25m;
        Console.WriteLine("Цельсий: " + temperature.Celsius);
        Console.WriteLine("Фаренгейт: " + temperature.Fahrenheit);

        try
        {
            temperature.Celsius = -300m;
        }
        catch (ArgumentOutOfRangeException)
        {
            Console.WriteLine("Нельзя установить температуру ниже абсолютного нуля.");
        }
    }

    private class Temperature
    {
        private decimal celsius;

        /// <summary>Температура по Цельсию.</summary>
        public decimal Celsius
        {
            get => celsius;
            set
            {
                if (value < -273.15m)
                    throw new ArgumentOutOfRangeException(nameof(Celsius));
                celsius = value;
            }
        }

        /// <summary>Температура по Фаренгейту.</summary>
        public decimal Fahrenheit => Celsius * 9m / 5m + 32m;
    }
}
