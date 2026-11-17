using Practicum.Common;

namespace Practicum.Tasks.Level2;

public class Task16_StringExtensions : ITask
{
    public string Title => "Методы расширения string";
    public string Description => "Три метода для работы со строками.";
    public string[] Requirements => new[]
    {
        "IsPalindrome, WordCount, ReverseString",
        "Статический класс StringExtensions",
        "Проверить на нескольких строках"
    };


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

public static class StringExtensions
{
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

    public static string ReverseString(this string text)
    {
        char[] result = new char[text.Length];
        for (int i = 0; i < text.Length; i++)
            result[i] = text[text.Length - i - 1];
        return new string(result);
    }
}
