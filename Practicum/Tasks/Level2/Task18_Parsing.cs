using Practicum.Common;

namespace Practicum.Tasks.Level2;

public class Task18_Parsing : ITask
{
    public string Title => "TryParse и try/catch";
    public string Description => "Сравнить два способа чтения числа.";
    public string[] Requirements => new[]
    {
        "Метод с int.TryParse и out",
        "Метод с int.Parse и try/catch",
        "Проверить 123 и abc"
    };


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
