using Practicum.Common;

namespace Practicum.Tasks.Level3;

public class Task48_Git : ITask
{
    public string Title => "Git: аннотированный тег";
    public string Description => "Создать тег версии.";
    public string[] Requirements => new[]
    {
        "git tag -a v1.0.0",
        "git show v1.0.0",
        "git push origin v1.0.0"
    };

    public void Run()
    {
        Console.WriteLine("Результаты упражнения — в git-notes.md.");
    }
}
