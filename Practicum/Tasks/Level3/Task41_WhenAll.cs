using Practicum.Common;

namespace Practicum.Tasks.Level3;

/// <summary>Задание №41.</summary>
public class Task41_WhenAll : ITask
{
    /// <summary>Название задания.</summary>
    public string Title => "Task.WhenAll";
    /// <summary>Описание задания.</summary>
    public string Description => "Сравнить последовательные и параллельные задачи.";
    /// <summary>Условия задания.</summary>
    public string[] Requirements => new[]
    {
        "WorkAsync с задержкой 500 мс",
        "10 последовательных вызовов",
        "10 вызовов через Task.WhenAll"
    };

    /// <summary>Ожидаемый результат.</summary>
    public string ExpectedResult => "Результаты совпадают, параллельный запуск быстрее.";
    /// <summary>Подсказка.</summary>
    public string Hint => "Task.WhenAll ждёт все задачи одновременно.";

    /// <summary>Запускает задание.</summary>
    public void Run()
    {
        RunAsync().GetAwaiter().GetResult();
    }

    private static async Task RunAsync()
    {
        System.Diagnostics.Stopwatch timer = System.Diagnostics.Stopwatch.StartNew();
        List<int> first = new List<int>();
        for (int i = 1; i <= 10; i++)
            first.Add(await WorkAsync(i));
        timer.Stop();
        double time1 = timer.Elapsed.TotalMilliseconds;

        timer.Restart();
        Task<int>[] tasks = new Task<int>[10];
        for (int i = 0; i < 10; i++)
            tasks[i] = WorkAsync(i + 1);
        int[] second = await Task.WhenAll(tasks);
        timer.Stop();
        double time2 = timer.Elapsed.TotalMilliseconds;

        Console.WriteLine("По очереди: " + time1.ToString("F0") + " мс");
        Console.WriteLine("Одновременно: " + time2.ToString("F0") + " мс");
        Console.WriteLine("Результаты совпадают: " + first.SequenceEqual(second));
        // WhenAll ждёт все задачи вместе, а не каждую по очереди.
    }

    private static async Task<int> WorkAsync(int id)
    {
        await Task.Delay(500);
        return id;
    }
}
