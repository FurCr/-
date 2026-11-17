using Practicum.Common;

namespace Practicum.Tasks.Level2;

/// <summary>Задание №27.</summary>
public class Task27_Students : ITask
{
    /// <summary>Название задания.</summary>
    public string Title => "Сортировка студентов";
    /// <summary>Описание задания.</summary>
    public string Description => "Сортировка студентов по оценке и по имени.";
    /// <summary>Условия задания.</summary>
    public string[] Requirements => new[]
    {
        "IComparable<Student> по убыванию балла",
        "IComparer<Student> по имени",
        "Показать обе сортировки"
    };

    /// <summary>Запускает задание.</summary>
    public void Run()
    {
        List<Student> students = new List<Student>
        {
            new Student("Оля", 4.6),
            new Student("Иван", 3.8),
            new Student("Аня", 4.9),
            new Student("Дима", 4.2)
        };

        students.Sort();
        Console.WriteLine("По среднему баллу:");
        Print(students);

        students.Sort(new ByNameComparer());
        Console.WriteLine("По имени:");
        Print(students);
    }

    private static void Print(List<Student> students)
    {
        foreach (Student student in students)
            Console.WriteLine(student.Name + ": " + student.AverageGrade);
    }

    private class Student : IComparable<Student>
    {
        /// <summary>Имя.</summary>
        public string Name { get; }
        /// <summary>Средняя оценка.</summary>
        public double AverageGrade { get; }

        /// <summary>Выполняет действие.</summary>
        public Student(string name, double averageGrade)
        {
            Name = name;
            AverageGrade = averageGrade;
        }

        /// <summary>Выполняет действие.</summary>
        public int CompareTo(Student? other)
        {
            if (other == null) return -1;
            return other.AverageGrade.CompareTo(AverageGrade);
        }
    }

    private class ByNameComparer : IComparer<Student>
    {
        /// <summary>Выполняет действие.</summary>
        public int Compare(Student? a, Student? b)
        {
            return string.Compare(a?.Name, b?.Name, StringComparison.CurrentCulture);
        }
    }
}
