using Practicum.Common;

namespace Practicum.Tasks.Level3;

/// <summary>Задание №42.</summary>
public class Task42_Cancellation : ITask
{
    /// <summary>Название задания.</summary>
    public string Title => "Отмена операции";
    /// <summary>Описание задания.</summary>
    public string Description => "Остановить длительную задачу через две секунды.";
    /// <summary>Условия задания.</summary>
    public string[] Requirements => new[]
    {
        "CancellationTokenSource",
        "Task.Delay(500, token) в цикле",
        "Поймать OperationCanceledException"
    };

    /// <summary>Ожидаемый результат.</summary>
    public string ExpectedResult => "Операция отменяется без падения программы.";
    /// <summary>Подсказка.</summary>
    public string Hint => "Передай токен в Task.Delay.";

    /// <summary>Запускает задание.</summary>
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
