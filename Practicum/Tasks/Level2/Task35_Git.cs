using Practicum.Common;

namespace Practicum.Tasks.Level2;

public class Task35_Git : ITask
{
    public string Title => "Git: ветки, PR и rebase";
    public string Description => "Работа с ветками и историей Git.";
    public string[] Requirements => new[]
    {
        ".gitignore и .editorconfig",
        "Ветка и Pull Request",
        "Объединение коммитов и записи в git-notes.md"
    };

    public void Run()
    {
        Console.WriteLine("Результаты задания записаны в git-notes.md.");
    }
}
