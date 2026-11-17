using System;
using System.Collections.Generic;
using System.Text;

using Practicum.Common;

namespace Practicum.Tasks.Level1;

/// <summary>Задание №12.</summary>
public class Task12_Palindrome : ITask
{
    /// <summary>Название задания.</summary>
    public string Title => "Палиндром (без учёта регистра/пробелов)";
    /// <summary>Описание задания.</summary>
    public string Description => "Проверить, является ли строка палиндромом.";
    /// <summary>Условия задания.</summary>
    public string[] Requirements => new[]
    {
        "Игнорировать регистр (ToLower/ToUpper)",
        "Игнорировать пробелы и знаки пунктуации (или хотя бы пробелы)",
        "Не использовать LINQ Reverse",
        "Пустая строка и строка из одного символа — палиндром"
    };

    /// <summary>Запускает задание.</summary>
    public void Run()
    {
        Console.Write("Введите строку: ");
        string input = Console.ReadLine() ?? "";
        Console.WriteLine($"Палиндром: {IsPalindrome(input)}");
    }

    private bool IsPalindrome(string s)
    {

        string clean = "";
        foreach (char c in s)
        {
            if (char.IsLetterOrDigit(c))
                clean += char.ToLower(c);
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
}
