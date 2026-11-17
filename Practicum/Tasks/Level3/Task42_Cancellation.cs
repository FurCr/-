using Practicum.Common;

namespace Practicum.Tasks.Level3;

public class Task42_Cancellation : ITask
{
    public string Title => "Отмена операции";
    public string Description => "Остановить длительную задачу через две секунды.";
    public string[] Requirements => new[]
    {
        "CancellationTokenSource",
        "Task.Delay(500, token) в цикле",
        "Поймать OperationCanceledException"
    };

    public void Run()
    {
        RunAsync().GetAwaiter().GetResult();
    }

    private static async Task RunAsync()
    {
        using CancellationTokenSource source = new CancellationTokenSource();
        source.CancelAfter(2000);

        try
        {
            await LongOperationAsync(source.Token);
        }
        catch (OperationCanceledException)
        {
            Console.WriteLine("Операция отменена.");
        }
    }

    private static async Task LongOperationAsync(CancellationToken token)
    {
        for (int i = 1; i <= 10; i++)
        {
            await Task.Delay(500, token);
            Console.WriteLine("Шаг " + i);
        }
    }
}
