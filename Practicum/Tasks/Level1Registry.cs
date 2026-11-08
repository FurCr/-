using System;
using System.Collections.Generic;
using System.Text;

using Practicum.Common;

namespace Practicum.Tasks.Level1;


public static class Level1Registry
{
    
    public static ITask[] Tasks { get; } = new ITask[]
    {
        new Task01_HelloWorld()
    };
}
