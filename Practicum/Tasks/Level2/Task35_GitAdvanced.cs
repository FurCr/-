using System;
using System.Collections.Generic;
using System.Text;

using Practicum.Common;

namespace Practicum.Tasks.Level2;

/// <summary>Задание 35. Git: .gitignore, .editorconfig, PR, rebase.</summary>
public class Task35_GitAdvanced : ITask
{
    public string Title => "Git: .gitignore, .editorconfig, PR, Conventional Commits, rebase";
    public string Description => "Пройти продвинутый git-сценарий.";
    public string[] Requirements => new[]
    {
        "Добавить .gitignore и .editorconfig отдельным коммитом",
        "Создать ветку feature/task-35, сделать 2–3 коммита",
        "Запушить ветку, открыть Pull Request в main",
        "Смержить PR, создать ветку feature/rebase-demo",
        "Объединить коммиты через git rebase -i HEAD~3",
        "Сохранить вывод в git-notes.md"
    };

    public void Run()
    {
        Console.WriteLine("Это Git-задание. Выполни шаги по инструкции и заполни git-notes.md.");
        Console.WriteLine("Кода на C# здесь нет.");
    }
}