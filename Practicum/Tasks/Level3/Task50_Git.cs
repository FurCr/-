using Practicum.Common;

namespace Practicum.Tasks.Level3;

/// <summary>Задание №50.</summary>
public class Task50_Git : ITask
{
    /// <summary>Название задания.</summary>
    public string Title => "Git: bisect";
    /// <summary>Описание задания.</summary>
    public string Description => "Найти сломанный коммит.";
    /// <summary>Условия задания.</summary>
    public string[] Requirements => new[]
    {
        "История из 10+ коммитов",
        "git bisect good и bad",
        "git bisect reset"
    };

    /// <summary>Ожидаемый результат.</summary>
    public string ExpectedResult => "Первый ошибочный коммит найден, поиск завершён.";
    /// <summary>Подсказка.</summary>
    public string Hint => "Команды и найденный коммит указаны в git-notes.md.";

    /// <summary>Запускает задание.</summary>
    public void Run()
    {
        Console.WriteLine("Результаты упражнения — в git-notes.md.");
    }
}
