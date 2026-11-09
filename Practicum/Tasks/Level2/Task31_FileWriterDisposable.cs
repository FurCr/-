using System;
using System.Collections.Generic;
using System.Text;

using Practicum.Common;

namespace Practicum.Tasks.Level2;

/// <summary>Задание 31. IDisposable + using.</summary>
public class Task31_FileWriterDisposable : ITask
{
    public string Title => "IDisposable + using";
    public string Description => "Реализовать IDisposable для класса, работающего с файлом.";
    public string[] Requirements => new[]
    {
        "Класс FileWriter с полем StreamWriter",
        "Реализовать Dispose() (закрыть StreamWriter)",
        "Продемонстрировать использование через using",
        "Дополнительно: продемонстрировать using-декларацию (C# 8+, using var)"
    };

    public void Run()
    {
        string filePath = "test_disposable.txt";

        using (var writer = new FileWriter(filePath))
        {
            writer.WriteLine("Строка 1");
            writer.WriteLine("Строка 2");
        }

        Console.WriteLine("Файл успешно записан и закрыт через блок using.");

        using var writer2 = new FileWriter("test_disposable_2.txt");
        writer2.WriteLine("Строка 3");
        Console.WriteLine("Второй файл записан через using-декларацию.");
    }
}

public class FileWriter : IDisposable
{
    private readonly StreamWriter _writer;
    private bool _disposed = false;

    public FileWriter(string path)
    {
        _writer = new StreamWriter(path);
    }

    public void WriteLine(string text)
    {
        if (_disposed) throw new ObjectDisposedException(nameof(FileWriter));
        _writer.WriteLine(text);
    }

    public void Dispose()
    {
        if (!_disposed)
        {
            _writer?.Dispose();
            _disposed = true;
        }
        GC.SuppressFinalize(this);
    }
}