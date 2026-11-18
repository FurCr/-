using Practicum.Common;

namespace Practicum.Tasks.Level2;

/// <summary>Задание №35.</summary>
public class Task35_Git : ITask
{
    /// <summary>Название задания.</summary>
    public string Title => "Git: ветки, PR и rebase";
    /// <summary>Описание задания.</summary>
    public string Description => "Работа с ветками и историей Git.";
    /// <summary>Условия задания.</summary>
    public string[] Requirements => new[]
    {
        ".gitignore и .editorconfig",
        "Ветка и Pull Request",
        "Объединение коммитов и записи в git-notes.md"
    };

    /// <summary>Ожидаемый результат.</summary>
    public string ExpectedResult => "Настройки Git, PR и rebase отражены в git-notes.md.";
    /// <summary>Подсказка.</summary>
    public string Hint => "Git-команды и результаты собраны в файле git-notes.md.";

    /// <summary>Запускает задание.</summary>
    public void Run()
    {
        Console.WriteLine("Результаты задания записаны в git-notes.md.");
    }
}
