using System.Text.Json;
using Practicum.Common;

namespace Practicum.Tasks.Level3;

/// <summary>Задание №44.</summary>
public class Task44_Todo : ITask
{
    /// <summary>Название задания.</summary>
    public string Title => "Список дел";
    /// <summary>Описание задания.</summary>
    public string Description => "Добавление, просмотр, завершение и удаление задач.";
    /// <summary>Условия задания.</summary>
    public string[] Requirements => new[]
    {
        "TaskItem, TaskRepository, TaskService",
        "CRUD для списка дел",
        "Сохранение в tasks.json"
    };

    /// <summary>Запускает задание.</summary>
    public void Run()
    {
        TaskService service = new TaskService(new TaskRepository());

        while (true)
        {
            Console.WriteLine("\n1. Добавить");
            Console.WriteLine("2. Показать все");
            Console.WriteLine("3. Отметить выполненной");
            Console.WriteLine("4. Удалить");
            Console.WriteLine("0. Назад");
            Console.Write("Выберите действие: ");
            string choice = Console.ReadLine() ?? "";
            if (choice == "0") return;

            try
            {
                switch (choice)
                {
                    case "1":
                        Console.Write("Название задачи: ");
                        string title = Console.ReadLine() ?? "";
                        if (string.IsNullOrWhiteSpace(title))
                            Console.WriteLine("Название не может быть пустым.");
                        else
                            service.Add(title);
                        break;
                    case "2":
                        service.ShowAll();
                        break;
                    case "3":
                        Console.Write("Номер задачи: ");
                        if (int.TryParse(Console.ReadLine(), out int doneId))
                            Console.WriteLine(service.Complete(doneId) ? "Готово." : "Задача не найдена.");
                        else
                            Console.WriteLine("Неверный номер.");
                        break;
                    case "4":
                        Console.Write("Номер задачи: ");
                        if (int.TryParse(Console.ReadLine(), out int deleteId))
                            Console.WriteLine(service.Delete(deleteId) ? "Удалено." : "Задача не найдена.");
                        else
                            Console.WriteLine("Неверный номер.");
                        break;
                    default:
                        Console.WriteLine("Неверный выбор.");
                        break;
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine("Ошибка файла: " + ex.Message);
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("Нет доступа к файлу.");
            }
        }
    }

    /// <summary>Задача из списка дел.</summary>
    public class TaskItem
    {
        /// <summary>Номер записи.</summary>
        public int Id { get; set; }
        /// <summary>Название задачи.</summary>
        public string Title { get; set; } = "";
        /// <summary>Завершена ли задача.</summary>
        public bool IsDone { get; set; }
    }

    private class TaskRepository
    {
        private List<TaskItem> tasks = new List<TaskItem>();
        private const string FileName = "tasks.json";

        /// <summary>Загружает задачи из файла.</summary>
        public TaskRepository()
        {
            if (!File.Exists(FileName)) return;
            try
            {
                tasks = JsonSerializer.Deserialize<List<TaskItem>>(File.ReadAllText(FileName))
                        ?? new List<TaskItem>();
            }
            catch (JsonException)
            {
                Console.WriteLine("Файл tasks.json повреждён.");
            }
            catch (IOException)
            {
                Console.WriteLine("Не удалось прочитать tasks.json.");
            }
        }

        /// <summary>Возвращает список задач.</summary>
        public List<TaskItem> GetAll() => tasks;

        /// <summary>Добавляет задачу.</summary>
        public void Add(string title)
        {
            int nextId = tasks.Count == 0 ? 1 : tasks.Max(t => t.Id) + 1;
            tasks.Add(new TaskItem { Id = nextId, Title = title });
            Save();
        }

        /// <summary>Отмечает задачу выполненной.</summary>
        public bool Complete(int id)
        {
            TaskItem? task = tasks.Find(t => t.Id == id);
            if (task == null) return false;
            task.IsDone = true;
            Save();
            return true;
        }

        /// <summary>Удаляет задачу.</summary>
        public bool Delete(int id)
        {
            TaskItem? task = tasks.Find(t => t.Id == id);
            if (task == null) return false;
            tasks.Remove(task);
            Save();
            return true;
        }

        private void Save()
        {
            string json = JsonSerializer.Serialize(tasks, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(FileName, json);
        }
    }

    private class TaskService
    {
        private TaskRepository repository;

        /// <summary>Создаёт сервис задач.</summary>
        public TaskService(TaskRepository repository)
        {
            this.repository = repository;
        }

        /// <summary>Добавляет задачу.</summary>
        public void Add(string title) => repository.Add(title);
        /// <summary>Отмечает задачу выполненной.</summary>
        public bool Complete(int id) => repository.Complete(id);
        /// <summary>Удаляет задачу.</summary>
        public bool Delete(int id) => repository.Delete(id);

        /// <summary>Показывает список задач.</summary>
        public void ShowAll()
        {
            List<TaskItem> tasks = repository.GetAll();
            if (tasks.Count == 0)
            {
                Console.WriteLine("Список пуст.");
                return;
            }

            foreach (TaskItem task in tasks)
                Console.WriteLine(task.Id + ". [" + (task.IsDone ? "x" : " ") + "] " + task.Title);
        }
    }
}
