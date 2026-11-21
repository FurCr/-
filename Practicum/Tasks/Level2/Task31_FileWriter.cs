using Practicum.Common;

namespace Practicum.Tasks.Level2;

/// <summary>Задание №31.</summary>
public class Task31_FileWriter : ITask
{
    /// <summary>Название задания.</summary>
    public string Title => "IDisposable и using";
    /// <summary>Описание задания.</summary>
    public string Description => "Запись в файл и закрытие через using.";
    /// <summary>Условия задания.</summary>
    public string[] Requirements => new[]
    {
        "FileWriter со StreamWriter",
        "Реализовать IDisposable",
        "using и using var"
    };

    /// <summary>Запускает задание.</summary>
    public void Run()
    {
        string file = Path.Combine(Path.GetTempPath(), "practice_writer.txt");

        using (FileWriter writer = new FileWriter(file))
        {
            writer.Write("Первая строка");
        }

        using var secondWriter = new FileWriter(file, true);
        secondWriter.Write("Вторая строка");

        Console.WriteLine("Обе записи выполнены.");
    }

    private class FileWriter : IDisposable
    {
        private StreamWriter writer;

        /// <summary>Открывает файл для записи.</summary>
        public FileWriter(string path, bool append = false)
        {
            writer = new StreamWriter(path, append);
        }

        /// <summary>Записывает строку в файл.</summary>
        public void Write(string text)
        {
            writer.WriteLine(text);
            writer.Flush();
        }

        /// <summary>Закрывает файл.</summary>
        public void Dispose()
        {
            writer.Dispose();
        }
    }
}
