using Practicum.Common;

namespace Practicum.Tasks.Level2;

public class Task31_FileWriter : ITask
{
    public string Title => "IDisposable и using";
    public string Description => "Запись в файл и закрытие через using.";
    public string[] Requirements => new[]
    {
        "FileWriter со StreamWriter",
        "Реализовать IDisposable",
        "using и using var"
    };

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

        public FileWriter(string path, bool append = false)
        {
            writer = new StreamWriter(path, append);
        }

        public void Write(string text)
        {
            writer.WriteLine(text);
            writer.Flush();
        }

        public void Dispose()
        {
            writer.Dispose();
        }
    }
}
