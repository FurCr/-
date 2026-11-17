using Practicum.Common;

namespace Practicum.Tasks.Level3;

public static class Level3Registry
{
    public static ITask[] Tasks { get; } = new ITask[]
    {
        new Task36_Duplicates(),
        new Task37_Fibonacci(),
        new Task38_ListBenchmark(),
        new Task39_Yield()
    };
}
