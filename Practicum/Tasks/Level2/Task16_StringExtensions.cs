using Practicum.Common;

namespace Practicum.Tasks.Level2;

/// <summary>Задание №16.</summary>
public class Task16_StringExtensions : ITask
{
    /// <summary>Название задания.</summary>
    public string Title => "Методы расширения string";
    /// <summary>Описание задания.</summary>
    public string Description => "Три метода для работы со строками.";
    /// <summary>Условия задания.</summary>
    public string[] Requirements => new[]
    {
        "IsPalindrome, WordCount, ReverseString",
        "Статический класс StringExtensions",
        "Проверить на нескольких строках"
    };


    /// <summary>Ожидаемый результат.</summary>
    public string ExpectedResult => "Три метода работают для нескольких строк.";
    /// <summary>Подсказка.</summary>
    public string Hint => "Первый параметр метода расширения пишется this string.";

    /// <summary>Запускает задание.</summary>
    public void Run()
    {
        string[] examples = { "топот", "Добрый день!", "А роза упала на лапу Азора" };
        foreach (string text in examples)
        {
            Console.WriteLine("Строка: " + text);
            Console.WriteLine("Палиндром: " + text.IsPalindrome());
            Console.WriteLine("Количество слов: " + text.WordCount());
            Console.WriteLine("Наоборот: " + text.ReverseString());
            Console.WriteLine();
        }
    }
}

/// <summary>Методы расширения строк.</summary>
public static class StringExtensions
{
    /// <summary>Обрабатывает строку.</summary>
    public static bool IsPalindrome(this string text)
    {
        string clean = "";
        foreach (char letter in text)
        {
            if (char.IsLetterOrDigit(letter))
                clean += char.ToLower(letter);
        }

        int left = 0;
        int right = clean.Length - 1;
        while (left < right)
        {
            if (clean[left] != clean[right])
                return false;
            left++;
            right--;
        }
        return true;
    }

    /// <summary>Обрабатывает строку.</summary>
    public static int WordCount(this string text)
    {
        int count = 0;
        bool inWord = false;
        foreach (char letter in text)
        {
            if (char.IsLetterOrDigit(letter))
            {
                if (!inWord)
                    count++;
                inWord = true;
            }
            else
            {
                inWord = false;
            }
        }
        return count;
    }

    /// <summary>Обрабатывает строку.</summary>
    public static string ReverseString(this string text)
    {
        char[] result = new char[text.Length];
        for (int i = 0; i < text.Length; i++)
            result[i] = text[text.Length - i - 1];
        return new string(result);
    }
}
