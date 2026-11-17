using Practicum.Common;

namespace Practicum.Tasks.Level2;

public static class Level2Registry
{
    public static ITask[] Tasks { get; } = new ITask[]
    {
        new Task16_StringExtensions(),
        new Task17_StringBuilder(),
        new Task18_Parsing(),
        new Task19_StackQueue(),
        new Task20_Generics(),
        new Task21_WeekDays(),
        new Task22_Params(),
        new Task23_Nullable(),
        new Task24_Animals(),
        new Task25_Shapes(),
        new Task26_Discounts(),
        new Task27_Students()
    };
}
