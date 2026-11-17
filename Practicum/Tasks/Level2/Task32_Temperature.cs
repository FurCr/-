using Practicum.Common;

namespace Practicum.Tasks.Level2;

public class Task32_Temperature : ITask
{
    public string Title => "Свойства с проверкой";
    public string Description => "Проверить температуру и перевести в Фаренгейты.";
    public string[] Requirements => new[]
    {
        "Celsius не ниже -273.15",
        "ArgumentOutOfRangeException",
        "Вычисляемое Fahrenheit"
    };

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

        public decimal Fahrenheit => Celsius * 9m / 5m + 32m;
    }
}
