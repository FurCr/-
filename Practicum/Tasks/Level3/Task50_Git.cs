using Practicum.Common;

namespace Practicum.Tasks.Level3;

public class Task50_Git : ITask
{
    public string Title => "Git: bisect";
    public string Description => "Найти сломанный коммит.";
    public string[] Requirements => new[]
    {
        "История из 10+ коммитов",
        "git bisect good и bad",
        "git bisect reset"
    };

    public void Run()
    {
        Console.WriteLine("Результаты упражнения — в git-notes.md.");
    }
}
