using System;
using System.Collections.Generic;
using System.Text;

using Practicum.Common;

namespace Practicum.Tasks.Level2;


public static class Level2Registry
{
  
    public static ITask[] Tasks { get; } = new ITask[]
    {
        new Task16_StringExtensions(),
        new Task17_StringBuilderVsConcat(),
        new Task18_TryParseVsTryCatch(),
        new Task19_MyStackAndQueue(),
        new Task20_GenericsSwapMax(),
        new Task21_EnumDayOfWeek(),
        new Task22_ParamsAndOverload(),
        new Task23_NullableTypes(),
        new Task24_AnimalPolymorphism(),
        new Task25_IShape(),
        new Task26_DiscountStrategy(),
        new Task27_StudentSorting(),
        new Task28_PointEquality(),
        new Task29_NotificationFactory(),
        new Task30_BankAccount(),
        new Task31_FileWriterDisposable(),
        new Task32_Temperature(),
        new Task33_LinqEmployees(),
        new Task34_LinqGrouping(),
        new Task35_GitAdvanced()
    };
}
