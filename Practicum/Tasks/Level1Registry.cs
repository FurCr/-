using System;
using System.Collections.Generic;
using System.Text;

using Practicum.Common;

namespace Practicum.Tasks.Level1;

/// <summary>Регистрирует все задания уровня 1.</summary>
public static class Level1Registry
{
    public static ITask[] Tasks { get; } = new ITask[]
    {
        new Task01_HelloWorld(),
        new Task02_Primitives(),   // добавили
        new Task03_Calculator()    // добавили
    };
}
