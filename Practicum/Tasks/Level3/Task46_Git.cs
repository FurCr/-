using Practicum.Common;

namespace Practicum.Tasks.Level3;

/// <summary>Задание №46.</summary>
public class Task46_Git : ITask
{
    /// <summary>Название задания.</summary>
    public string Title => "Git: stash";
    /// <summary>Описание задания.</summary>
    public string Description => "Скрыть и вернуть изменения.";
    /// <summary>Условия задания.</summary>
    public string[] Requirements => new[]
    {
        "git stash и stash list",
        "Переключение веток",
        "git stash pop"
    };

    /// <summary>Запускает задание.</summary>
    public void Run()
    {
        Console.WriteLine("Команды и результат — в git-notes.md.");
    }
}
