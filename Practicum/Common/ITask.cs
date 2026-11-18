using System;
using System.Collections.Generic;
using System.Text;

namespace Practicum.Common;
/// <summary>Общий интерфейс задания.</summary>
public interface ITask
{
    
    /// <summary>Название задания.</summary>
    string Title { get; }
    /// <summary>Описание задания.</summary>
    string Description { get; }
    /// <summary>Требования задания.</summary>
    string[] Requirements { get; }
    /// <summary>Ожидаемый результат.</summary>
    string ExpectedResult { get; }
    /// <summary>Подсказка.</summary>
    string Hint { get; }
    /// <summary>Запускает задание.</summary>
    void Run();
}