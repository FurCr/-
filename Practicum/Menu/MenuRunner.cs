using Practicum.Common;
using Practicum.Tasks.Level1;
using Practicum.Tasks.Level2;
using Practicum.Tasks.Level3;

namespace Practicum.Menu;

public class MenuRunner
{
    public void Run()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== Практикум по C# ===");
            Console.WriteLine("1. Уровень 1 — Базовый (1–15)");
            Console.WriteLine("2. Уровень 2 — Средний (16–35)");
            Console.WriteLine("3. Уровень 3 — Продвинутый (36–50)");
            Console.WriteLine("4. Выход");
            Console.Write("Выберите уровень: ");

            string choice = Console.ReadLine() ?? "";
            switch (choice)
            {
                case "1":
                    RunLevel("Уровень 1: Базовый", Level1Registry.Tasks, 1);
                    break;
                case "2":
                    RunLevel("Уровень 2: Средний", Level2Registry.Tasks, 16);
                    break;
                case "3":
                    RunLevel("Уровень 3: Продвинутый", Level3Registry.Tasks, 36);
                    break;
                case "0":
                case "4":
                case "q":
                    return;
                default:
                    Console.WriteLine("Неверный выбор. Нажмите Enter...");
                    Console.ReadLine();
                    break;
            }
        }
    }

    private void RunLevel(string title, ITask[] tasks, int firstNumber)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("--- " + title + " ---");
            for (int i = 0; i < tasks.Length; i++)
                Console.WriteLine((firstNumber + i) + ". " + tasks[i].Title);

            Console.WriteLine("0. Назад");
            Console.Write("Выберите задание: ");
            string input = Console.ReadLine() ?? "";

            if (input == "0")
                return;

            if (int.TryParse(input, out int number) &&
                number >= firstNumber && number < firstNumber + tasks.Length)
            {
                Console.Clear();
                ITask task = tasks[number - firstNumber];
                ConsoleHelper.PrintTaskHeader(number.ToString(), task);
                try
                {
                    task.Run();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ошибка: " + ex.Message);
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
