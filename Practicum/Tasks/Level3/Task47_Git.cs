using Practicum.Common;

namespace Practicum.Tasks.Level3;

/// <summary>Задание №47.</summary>
public class Task47_Git : ITask
{
    /// <summary>Название задания.</summary>
    public string Title => "Git: rebase -i";
    /// <summary>Описание задания.</summary>
    public string Description => "Объединить четыре коммита.";
    /// <summary>Условия задания.</summary>
    public string[] Requirements => new[]
    {
        "Ветка feature/squash-demo",
        "Четыре коммита и squash",
        "История до и после в git-notes.md"
    };

    /// <summary>Ожидаемый результат.</summary>
    public string ExpectedResult => "Четыре коммита объединены в один.";
    /// <summary>Подсказка.</summary>
    public string Hint => "Вывод git log сохранён в git-notes.md.";

    /// <summary>Запускает задание.</summary>
    public void Run()
    {
        Console.WriteLine("Результат упражнения — в git-notes.md.");
    }
}
