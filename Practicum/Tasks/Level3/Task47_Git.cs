using Practicum.Common;

namespace Practicum.Tasks.Level3;

public class Task47_Git : ITask
{
    public string Title => "Git: rebase -i";
    public string Description => "Объединить четыре коммита.";
    public string[] Requirements => new[]
    {
        "Ветка feature/squash-demo",
        "Четыре коммита и squash",
        "История до и после в git-notes.md"
    };

    public void Run()
    {
        Console.WriteLine("Результат упражнения — в git-notes.md.");
    }
}
