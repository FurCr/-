using Practicum.Common;

namespace Practicum.Tasks.Level3;

/// <summary>Задание №49.</summary>
public class Task49_Git : ITask
{
    /// <summary>Название задания.</summary>
    public string Title => "Git: reflog";
    /// <summary>Описание задания.</summary>
    public string Description => "Восстановить коммит через reflog.";
    /// <summary>Условия задания.</summary>
    public string[] Requirements => new[]
    {
        "git reset --hard HEAD~1",
        "git reflog",
        "git reset --hard <hash>"
    };

    /// <summary>Запускает задание.</summary>
    public void Run()
    {
        Console.WriteLine("Результаты упражнения — в git-notes.md.");
    }
}
