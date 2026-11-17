using Practicum.Common;

namespace Practicum.Tasks.Level2;

/// <summary>Класс заданий или тестов.</summary>
public static class Level2Registry
{
    /// <summary>Список заданий.</summary>
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
        new Task27_Students(),
        new Task28_Points(),
        new Task29_Notifications(),
        new Task30_BankAccount(),
        new Task31_FileWriter(),
        new Task32_Temperature(),
        new Task33_Employees(),
        new Task34_WordGroups(),
        new Task35_Git()
    };
}
