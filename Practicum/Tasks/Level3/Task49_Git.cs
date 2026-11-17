using Practicum.Common;

namespace Practicum.Tasks.Level3;

public class Task49_Git : ITask
{
    public string Title => "Git: reflog";
    public string Description => "Восстановить коммит через reflog.";
    public string[] Requirements => new[]
    {
        "git reset --hard HEAD~1",
        "git reflog",
        "git reset --hard <hash>"
    };

    public void Run()
    {
        Console.WriteLine("Результаты упражнения — в git-notes.md.");
    }
}
