using Practicum.Common;

namespace Practicum.Tasks.Level3;

public class Task41_WhenAll : ITask
{
    public string Title => "Task.WhenAll";
    public string Description => "Сравнить последовательные и параллельные задачи.";
    public string[] Requirements => new[]
    {
        "WorkAsync с задержкой 500 мс",
        "10 последовательных вызовов",
        "10 вызовов через Task.WhenAll"
    };

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
