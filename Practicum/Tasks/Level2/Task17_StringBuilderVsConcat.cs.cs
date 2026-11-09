using System;
using System.Collections.Generic;
using System.Text;

using Practicum.Common;
using System.Diagnostics;


namespace Practicum.Tasks.Level2;

/// <summary>Задание 17. StringBuilder vs конкатенация (замер).</summary>
public class Task17_StringBuilderVsConcat : ITask
{
    public string Title => "StringBuilder vs конкатенация (замер)";
    public string Description => "Сравнить производительность конкатенации через + и StringBuilder.";
    public string[] Requirements => new[]
    {
        "Собрать строку из 10 000 (или 100 000) чисел двумя способами",
        "Замерить время каждого через Stopwatch",
        "Вывести оба времени и разницу",
        "Объяснить в комментарии, почему StringBuilder быстрее"
    };

    public void Run()
    {
        int count = 10000;

        Stopwatch sw1 = Stopwatch.StartNew();
        string result1 = "";
        for (int i = 0; i < count; i++)
        {
            result1 += i.ToString();
        }
        sw1.Stop();

        Stopwatch sw2 = Stopwatch.StartNew();
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < count; i++)
        {
            sb.Append(i);
        }
        string result2 = sb.ToString();
        sw2.Stop();

        Console.WriteLine($"Время через '+' : {sw1.ElapsedMilliseconds} мс");
        Console.WriteLine($"Время через StringBuilder: {sw2.ElapsedMilliseconds} мс");
        Console.WriteLine($"Строки идентичны: {result1 == result2}");

        // Объяснение: Строки в C# неизменяемы. При использовании '+' каждый раз создается новая строка в памяти,
        // а старая удаляется сборщиком мусора, что сильно замедляет работу. StringBuilder хранит внутри
        // массив символов и просто дописывает в него новые данные, не создавая новых строк.
    }
}