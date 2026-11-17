using Practicum.Common;

namespace Practicum.Tasks.Level3;

public static class Level3Registry
{
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
        new Task46_Git()
    };
}
