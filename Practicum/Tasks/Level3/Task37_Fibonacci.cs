using Practicum.Common;

namespace Practicum.Tasks.Level3;

public class Task37_Fibonacci : ITask
{
    public string Title => "Фибоначчи с запоминанием";
    public string Description => "Сравнить обычную рекурсию и Dictionary.";
    public string[] Requirements => new[]
    {
        "Два рекурсивных метода",
        "Dictionary<int, long> для сохранения",
        "Stopwatch для N = 35"
    };

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
