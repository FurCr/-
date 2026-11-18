using Practicum.Common;

namespace Practicum.Tasks.Level1;

/// <summary>Задание №15.</summary>
public class Task15_Git : ITask
{
    /// <summary>Название задания.</summary>
    public string Title => "Git: ветки и merge";
    /// <summary>Описание задания.</summary>
    public string Description => "Создать ветку, выполнить merge и решить конфликт.";
    /// <summary>Условия задания.</summary>
    public string[] Requirements => new[]
    {
        "git init, commit, branch",
        "merge и разрешение конфликта",
        "История в git-notes.md"
    };

    /// <summary>Ожидаемый результат.</summary>
    public string ExpectedResult => "Есть merge, разрешённый конфликт и история в git-notes.md.";
    /// <summary>Подсказка.</summary>
    public string Hint => "Результаты команд находятся в git-notes.md.";

    /// <summary>Запускает задание.</summary>
    public void Run()
    {
        Console.WriteLine("Результат задания — в git-notes.md.");
    }
}
