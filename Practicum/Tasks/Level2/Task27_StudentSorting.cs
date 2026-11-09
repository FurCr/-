using System;
using System.Collections.Generic;
using System.Text;

using Practicum.Common;

namespace Practicum.Tasks.Level2;

/// <summary>Задание 27. IComparable / IComparer&lt;T&gt; для Student.</summary>
public class Task27_StudentSorting : ITask
{
    public string Title => "IComparable / IComparer<T> для Student";
    public string Description => "Научить Student сортироваться.";
    public string[] Requirements => new[]
    {
        "Класс Student: Name, AverageGrade",
        "Реализовать IComparable<Student> — сортировка по среднему баллу (по убыванию)",
        "Реализовать IComparer<Student> ByNameComparer — сортировка по имени",
        "Продемонстрировать обе сортировки на List<Student>"
    };

    public void Run()
    {
        var students = new List<Student>
        {
            new Student("Алексей", 4.5),
            new Student("Мария", 5.0),
            new Student("Иван", 3.8),
            new Student("Ольга", 4.9)
        };

        Console.WriteLine("--- По среднему баллу (убывание) ---");
        students.Sort();
        foreach (var s in students) Console.WriteLine($"{s.Name}: {s.AverageGrade}");

        Console.WriteLine("\n--- По имени (алфавит) ---");
        students.Sort(new ByNameComparer());
        foreach (var s in students) Console.WriteLine($"{s.Name}: {s.AverageGrade}");
    }
}

public class Student : IComparable<Student>
{
    public string Name { get; set; }
    public double AverageGrade { get; set; }

    public Student(string name, double averageGrade)
    {
        Name = name;
        AverageGrade = averageGrade;
    }

    public int CompareTo(Student? other)
    {
        if (other == null) return 1;
        return other.AverageGrade.CompareTo(AverageGrade);
    }
}

public class ByNameComparer : IComparer<Student>
{
    public int Compare(Student? x, Student? y)
    {
        if (x == null || y == null) return 0;
        return string.Compare(x.Name, y.Name, StringComparison.Ordinal);
    }
}