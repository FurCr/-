using System;
using System.Collections.Generic;
using System.Text;

using Practicum.Common;

namespace Practicum.Tasks.Level2;


public class Task16_StringExtensions : ITask
{
    public string Title => "Методы расширения для string";
    public string Description => "Написать extension-методы для string.";
    public string[] Requirements => new[]
    {
        "Реализовать в статическом классе StringExtensions",
        "Методы: IsPalindrome(), WordCount(), ReverseString()",
        "Методы должны быть public static с this string первым параметром",
        "Продемонстрировать вызов на 2–3 строках"
    };

    public void Run()
    {
        string text1 = "А роза упала на лапу Азора";
        string text2 = "hello";
        string text3 = "Привет мир, как дела?";

        Console.WriteLine($"Строка 1: \"{text1}\"");
        Console.WriteLine($"Палиндром: {text1.IsPalindrome()}");
        Console.WriteLine($"Реверс: {text1.ReverseString()}");
        Console.WriteLine($"Количество слов: {text1.WordCount()}");

        Console.WriteLine($"\nСтрока 2: \"{text2}\"");
        Console.WriteLine($"Палиндром: {text2.IsPalindrome()}");
        Console.WriteLine($"Реверс: {text2.ReverseString()}");

        Console.WriteLine($"\nСтрока 3: \"{text3}\"");
        Console.WriteLine($"Количество слов: {text3.WordCount()}");
    }
}


public static class StringExtensions
{
    
    public static bool IsPalindrome(this string s)
    {
        string clean = "";
        foreach (char c in s)
        {
            if (char.IsLetterOrDigit(c)) clean += char.ToLower(c);
        }

        int left = 0;
        int right = clean.Length - 1;
        while (left < right)
        {
            if (clean[left] != clean[right]) return false;
            left++;
            right--;
        }
        return true;
    }

    public static string ReverseString(this string s)
    {
        char[] arr = s.ToCharArray();
        int left = 0;
        int right = arr.Length - 1;

        while (left < right)
        {
          
            char temp = arr[left];
            arr[left] = arr[right];
            arr[right] = temp;
            left++;
            right--;
        }
        return new string(arr);
    }

    public static int WordCount(this string s)
    {
      
        string[] words = s.Split(new[] { ' ', '.', ',', '!', '?', ';', ':', '-' },
            StringSplitOptions.RemoveEmptyEntries);
        return words.Length;
    }
}