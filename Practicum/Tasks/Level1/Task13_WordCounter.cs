using System;
using System.Collections.Generic;
using System.Text;

using Practicum.Common;

namespace Practicum.Tasks.Level1;


/// <summary>Задание №13.</summary>
public class Task13_WordCounter : ITask
{
    /// <summary>Название задания.</summary>
    public string Title => "Счётчик вхождений слов в тексте (Dictionary)";
    /// <summary>Описание задания.</summary>
    public string Description => "Посчитать, сколько раз каждое слово встречается в тексте.";
    /// <summary>Условия задания.</summary>
    public string[] Requirements => new[]
    {
        "Использовать Dictionary<string, int>",
        "Разбить текст на слова (по пробелам и знакам пунктуации)",
        "Привести слова к нижнему регистру",
        "Вывести пары «слово → количество», отсортированные по убыванию количества"
    };

    /// <summary>Ожидаемый результат.</summary>
    public string ExpectedResult => "Все слова посчитаны по убыванию частоты.";
    /// <summary>Подсказка.</summary>
    public string Hint => "Раздели строку через Split и используй OrderByDescending.";

    /// <summary>Запускает задание.</summary>
    public void Run()
    {
        Console.WriteLine("Введите текст:");
        string text = Console.ReadLine() ?? "";

        string prepared = "";
        foreach (char letter in text.ToLower())
            prepared += char.IsLetterOrDigit(letter) ? letter : ' ';

        string[] words = prepared.Split(' ', StringSplitOptions.RemoveEmptyEntries);

   
        var dict = new Dictionary<string, int>();
        foreach (var w in words)
        {
            if (dict.ContainsKey(w))
                dict[w]++;
            else
                dict[w] = 1; 
        }

        Console.WriteLine("\nСлова по убыванию частоты:");

        
        var list = new List<KeyValuePair<string, int>>(dict);
        list.Sort((a, b) => b.Value.CompareTo(a.Value));

        foreach (var kv in list)
        {
            Console.WriteLine($"{kv.Key} → {kv.Value}");
        }
    }
}