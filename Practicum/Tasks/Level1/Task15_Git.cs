using Practicum.Common;

namespace Practicum.Tasks.Level1;

public class Task15_Git : ITask
{
    public string Title => "Git: ветки и merge";
    public string Description => "Создать ветку, выполнить merge и решить конфликт.";
    public string[] Requirements => new[]
    {
        "git init, commit, branch",
        "merge и разрешение конфликта",
        "История в git-notes.md"
    };

    public void Run()
    {
        Console.WriteLine("Результат задания — в git-notes.md.");
    }
}
