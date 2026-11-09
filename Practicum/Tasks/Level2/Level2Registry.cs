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
        new Task20_GenericsSwapMax()
    };
}
