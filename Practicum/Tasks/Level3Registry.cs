using Practicum.Common;

namespace Practicum.Tasks.Level3;

/// <summary>Класс заданий или тестов.</summary>
public static class Level3Registry
{
    /// <summary>Список заданий.</summary>
    public static ITask[] Tasks { get; } = new ITask[]
    {
        new Task36_Duplicates(),
        new Task37_Fibonacci(),
        new Task38_ListBenchmark(),
        new Task39_Yield(),
        new Task40_AsyncDownload(),
        new Task41_WhenAll(),
        new Task42_Cancellation(),
        new Task43_Exceptions(),
        new Task44_Todo(),
        new Task45_Library(),
        new Task46_Git(),
        new Task47_Git(),
        new Task48_Git(),
        new Task49_Git(),
        new Task50_Git()
    };
}
