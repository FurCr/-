using Practicum.Common;

namespace Practicum.Tasks.Level2;

public class Task33_Employees : ITask
{
    public string Title => "LINQ: сотрудники";
    public string Description => "Вывести сотрудников по зарплате, отделам и возрасту.";
    public string[] Requirements => new[]
    {
        "Employee: Name, Age, Salary, Department",
        "Минимум 10 сотрудников",
        "Top 3, GroupBy Average, Where"
    };

    public void Run()
    {
        List<Employee> employees = new List<Employee>
        {
            new Employee("Анна", 25, 65000m, "Разработка"),
            new Employee("Иван", 31, 48000m, "Разработка"),
            new Employee("Мария", 35, 72000m, "Аналитика"),
            new Employee("Пётр", 28, 55000m, "Тестирование"),
            new Employee("Ольга", 33, 61000m, "Аналитика"),
            new Employee("Дима", 24, 42000m, "Тестирование"),
            new Employee("Елена", 41, 89000m, "Разработка"),
            new Employee("Сергей", 30, 53000m, "Аналитика"),
            new Employee("Наташа", 27, 59000m, "Разработка"),
            new Employee("Алексей", 38, 77000m, "Тестирование")
        };

        Console.WriteLine("Три самые высокие зарплаты:");
        foreach (Employee employee in employees.OrderByDescending(e => e.Salary).Take(3))
            Console.WriteLine(employee.Name + ": " + employee.Salary);

        Console.WriteLine("Средняя зарплата по отделам:");
        foreach (var group in employees.GroupBy(e => e.Department))
            Console.WriteLine(group.Key + ": " + group.Average(e => e.Salary).ToString("F2"));

        Console.WriteLine("Старше 30 лет:");
        foreach (Employee employee in employees.Where(e => e.Age > 30))
            Console.WriteLine(employee.Name + ": " + employee.Age);
    }

    private class Employee
    {
        public string Name { get; }
        public int Age { get; }
        public decimal Salary { get; }
        public string Department { get; }

        public Employee(string name, int age, decimal salary, string department)
        {
            Name = name;
            Age = age;
            Salary = salary;
            Department = department;
        }
    }
}
