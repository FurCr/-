using Practicum.Common;

namespace Practicum.Tasks.Level2;

public class Task27_Students : ITask
{
    public string Title => "Сортировка студентов";
    public string Description => "Сортировка студентов по оценке и по имени.";
    public string[] Requirements => new[]
    {
        "IComparable<Student> по убыванию балла",
        "IComparer<Student> по имени",
        "Показать обе сортировки"
    };

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
        public string Name { get; }
        public double AverageGrade { get; }

        public Student(string name, double averageGrade)
        {
            Name = name;
            AverageGrade = averageGrade;
        }

        public int CompareTo(Student? other)
        {
            if (other == null) return -1;
            return other.AverageGrade.CompareTo(AverageGrade);
        }
    }

    private class ByNameComparer : IComparer<Student>
    {
        public int Compare(Student? a, Student? b)
        {
            return string.Compare(a?.Name, b?.Name, StringComparison.CurrentCulture);
        }
    }
}
