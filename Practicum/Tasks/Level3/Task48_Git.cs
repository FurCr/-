using Practicum.Common;

namespace Practicum.Tasks.Level3;

/// <summary>Задание №48.</summary>
public class Task48_Git : ITask
{
    /// <summary>Название задания.</summary>
    public string Title => "Git: аннотированный тег";
    /// <summary>Описание задания.</summary>
    public string Description => "Создать тег версии.";
    /// <summary>Условия задания.</summary>
    public string[] Requirements => new[]
    {
        "git tag -a v1.0.0",
        "git show v1.0.0",
        "git push origin v1.0.0"
    };

    /// <summary>Запускает задание.</summary>
    public void Run()
    {
        Console.WriteLine("Результаты упражнения — в git-notes.md.");
    }
}
