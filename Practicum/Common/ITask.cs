using System;
using System.Collections.Generic;
using System.Text;

namespace Practicum.Common;
public interface ITask
{
    
    string Title { get; }
    string Description { get; }
    string[] Requirements { get; }
    void Run();
}