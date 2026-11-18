using Practicum.Common;

namespace Practicum.Tasks.Level3;

/// <summary>Задание №37.</summary>
public class Task37_Fibonacci : ITask
{
    /// <summary>Название задания.</summary>
    public string Title => "Фибоначчи с запоминанием";
    /// <summary>Описание задания.</summary>
    public string Description => "Сравнить обычную рекурсию и Dictionary.";
    /// <summary>Условия задания.</summary>
    public string[] Requirements => new[]
    {
        "Два рекурсивных метода",
        "Dictionary<int, long> для сохранения",
        "Stopwatch для N = 35"
    };

    /// <summary>Ожидаемый результат.</summary>
    public string ExpectedResult => "Результаты совпадают, мемоизация быстрее.";
    /// <summary>Подсказка.</summary>
    public string Hint => "Сохраняй уже вычисленные числа в Dictionary.";

    /// <summary>Запускает задание.</summary>
    public void Run()
    {
        int n = 35;
        System.Diagnostics.Stopwatch timer = System.Diagnostics.Stopwatch.StartNew();
        long first = Simple(n);
        timer.Stop();
        double time1 = timer.Elapsed.TotalMilliseconds;

        Dictionary<int, long> cache = new Dictionary<int, long>();
        timer.Restart();
        long second = WithCache(n, cache);
        timer.Stop();
        double time2 = timer.Elapsed.TotalMilliseconds;

        Console.WriteLine("Без кэша: " + first + ", " + time1.ToString("F3") + " мс");
        Console.WriteLine("С кэшем: " + second + ", " + time2.ToString("F3") + " мс");
        Console.WriteLine("Разница: " + (time1 - time2).ToString("F3") + " мс");
    }

    private static long Simple(int n)
    {
        if (n < 2) return n;
        return Simple(n - 1) + Simple(n - 2);
    }

    private static long WithCache(int n, Dictionary<int, long> cache)
    {
        if (n < 2) return n;
        if (cache.TryGetValue(n, out long result))
            return result;
        result = WithCache(n - 1, cache) + WithCache(n - 2, cache);
        cache[n] = result;
        return result;
    }
}
