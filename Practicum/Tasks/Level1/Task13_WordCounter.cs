using System;
using System.Collections.Generic;
using System.Text;

using Practicum.Common;

namespace Practicum.Tasks.Level1;


public class Task13_WordCounter : ITask
{
    public string Title => "Счётчик вхождений слов в тексте (Dictionary)";
    public string Description => "Посчитать, сколько раз каждое слово встречается в тексте.";
    public string[] Requirements => new[]
    {
        "Использовать Dictionary<string, int>",
        "Разбить текст на слова (по пробелам и знакам пунктуации)",
        "Привести слова к нижнему регистру",
        "Вывести пары «слово → количество», отсортированные по убыванию количества"
    };

    public void Run()
    {
        Console.WriteLine("Введите текст:");
        string text = Console.ReadLine() ?? "";

        var words = text.ToLower()
            .Split(new[] { ' ', '.', ',', '!', '?', ';', ':', '-', '\n', '\r', '\t' },
                   StringSplitOptions.RemoveEmptyEntries);

   
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