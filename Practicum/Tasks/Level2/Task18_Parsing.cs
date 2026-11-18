using Practicum.Common;

namespace Practicum.Tasks.Level2;

/// <summary>Задание №18.</summary>
public class Task18_Parsing : ITask
{
    /// <summary>Название задания.</summary>
    public string Title => "TryParse и try/catch";
    /// <summary>Описание задания.</summary>
    public string Description => "Сравнить два способа чтения числа.";
    /// <summary>Условия задания.</summary>
    public string[] Requirements => new[]
    {
        "Метод с int.TryParse и out",
        "Метод с int.Parse и try/catch",
        "Проверить 123 и abc"
    };


    /// <summary>Ожидаемый результат.</summary>
    public string ExpectedResult => "Оба способа обрабатывают 123 и abc.";
    /// <summary>Подсказка.</summary>
    public string Hint => "Каждый способ в отдельном методе.";

    /// <summary>Запускает задание.</summary>
    public void Run()
    {
        string[] examples = { "123", "abc" };
        foreach (string text in examples)
        {
            bool a = ReadWithTryParse(text, out int number1);
            bool b = ReadWithParse(text, out int number2);

            Console.WriteLine("Ввод: " + text);
            Console.WriteLine("TryParse: " + a + ", число: " + number1);
            Console.WriteLine("try/catch: " + b + ", число: " + number2);
        }
    }

    private static bool ReadWithTryParse(string text, out int number)
    {
        return int.TryParse(text, out number);
    }

    private static bool ReadWithParse(string text, out int number)
    {
        try
        {
            number = int.Parse(text);
            return true;
        }
        catch (FormatException)
        {
            number = 0;
            return false;
        }
        catch (OverflowException)
        {
            number = 0;
            return false;
        }
    }
}
