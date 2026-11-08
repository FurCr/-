using System;
using System.Collections.Generic;
using System.Text;

using Practicum.Common;
using Practicum.Tasks.Level1;

namespace Practicum.Menu;
public class MenuRunner
{
    public void Run()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== Практикум по C# ===");
            Console.WriteLine("1. Уровень 1 — Базовый (задания 1–15)");
            Console.WriteLine("2. Уровень 2 — Средний (задания 16–35)");
            Console.WriteLine("3. Уровень 3 — Продвинутый (задания 36–50)");
            Console.WriteLine("4. Выход");
            Console.Write("\nВыберите уровень: ");

            var choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    RunLevel("Уровень 1: Базовый", Level1Registry.Tasks);
                    break;
                case "4":
                case "q":
                case "0":
                    return;
                default:
                    Console.WriteLine("Неверный выбор. Нажмите Enter...");
                    Console.ReadLine();
                    break;
            }
        }
    }

    private void RunLevel(string title, ITask[] tasks)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine($"--- {title} ---");
            for (int i = 0; i < tasks.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {tasks[i].Title}");
            }
            Console.WriteLine("0. Назад");
            Console.Write("\nВыберите задание: ");

            var input = Console.ReadLine();
            if (input == "0") return;

            if (int.TryParse(input, out int n) && n >= 1 && n <= tasks.Length)
            {
                Console.Clear();
                var task = tasks[n - 1];
                ConsoleHelper.PrintTaskHeader($"{n}", task);
                try
                {
                    task.Run();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Произошла ошибка: {ex.Message}");
                }
                ConsoleHelper.Pause();
            }
            else
            {
                Console.WriteLine("Неверный номер. Нажмите Enter...");
                Console.ReadLine();
            }
        }
    }
}
