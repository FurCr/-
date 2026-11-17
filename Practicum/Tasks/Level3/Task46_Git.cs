using Practicum.Common;

namespace Practicum.Tasks.Level3;

public class Task46_Git : ITask
{
    public string Title => "Git: stash";
    public string Description => "Скрыть и вернуть изменения.";
    public string[] Requirements => new[]
    {
        "git stash и stash list",
        "Переключение веток",
        "git stash pop"
    };

    public void Run()
    {
        Console.WriteLine("Команды и результат — в git-notes.md.");
    }
}
