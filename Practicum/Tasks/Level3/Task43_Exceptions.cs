using Practicum.Common;

namespace Practicum.Tasks.Level3;

/// <summary>Задание №43.</summary>
public class Task43_Exceptions : ITask
{
    /// <summary>Название задания.</summary>
    public string Title => "Несколько исключений";
    /// <summary>Описание задания.</summary>
    public string Description => "Проверить разные catch и finally.";
    /// <summary>Условия задания.</summary>
    public string[] Requirements => new[]
    {
        "FormatException, DivideByZeroException, CustomException",
        "Сначала специальные catch, потом общий",
        "finally выполняется всегда"
    };

    /// <summary>Запускает задание.</summary>
    public void Run()
    {
        string[] cases = { "abc", "zero", "custom" };

        foreach (string value in cases)
        {
            try
            {
                Check(value);
            }
            catch (FormatException)
            {
                Console.WriteLine("Неверный формат числа.");
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Деление на ноль.");
            }
            catch (CustomException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка: " + ex.Message);
            }
            finally
            {
                Console.WriteLine("Завершено.");
            }
        }
    }

    private static void Check(string value)
    {
        if (value == "zero")
            throw new DivideByZeroException();
        if (value == "custom")
            throw new CustomException("Собственная ошибка.");
        int.Parse(value);
    }

    // Общий catch должен быть последним, иначе специальные не выполнятся.
    private class CustomException : Exception
    {
        /// <summary>Выполняет действие.</summary>
        public CustomException(string message) : base(message) { }
    }
}
