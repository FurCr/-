using System;
using System.Collections.Generic;
using System.Text;

using Practicum.Common;

namespace Practicum.Tasks.Level2;

/// <summary>Задание 33. LINQ: сотрудники.</summary>
public class Task33_LinqEmployees : ITask
{
    public string Title => "LINQ: сотрудники (top-3, avg по отделу, фильтр)";
    public string Description => "LINQ-запросы по списку сотрудников.";
    public string[] Requirements => new[]
    {
        "Класс Employee: Name, Age, Salary, Department",
        "Список из 10+ сотрудников",
        "Запросы через LINQ: топ-3 по зарплате (убывание), средняя зарплата по отделу, сотрудники старше 30",
        "Вывести результаты"
    };

    public void Run()
    {
        var employees = new List<Employee>
        {
            new Employee("Иван", 25, 50000, "IT"),
            new Employee("Мария", 32, 70000, "HR"),
            new Employee("Алексей", 35, 90000, "IT"),
            new Employee("Ольга", 28, 60000, "Sales"),
            new Employee("Дмитрий", 40, 120000, "IT"),
            new Employee("Елена", 31, 80000, "HR"),
            new Employee("Сергей", 22, 45000, "Sales"),
            new Employee("Анна", 29, 55000, "IT"),
            new Employee("Павел", 45, 150000, "Management"),
            new Employee("Татьяна", 38, 85000, "HR")
        };

        Console.WriteLine("--- Топ-3 по зарплате ---");
        var top3 = employees.OrderByDescending(e => e.Salary).Take(3);
        foreach (var e in top3) Console.WriteLine($"{e.Name} ({e.Salary})");

        Console.WriteLine("\n--- Средняя зарплата по отделам ---");
        var avgByDept = employees.GroupBy(e => e.Department)
            .Select(g => new { Department = g.Key, AvgSalary = g.Average(e => e.Salary) });
        foreach (var item in avgByDept) Console.WriteLine($"{item.Department}: {item.AvgSalary:F2}");

        Console.WriteLine("\n--- Сотрудники старше 30 ---");
        var olderThan30 = employees.Where(e => e.Age > 30);
        foreach (var e in olderThan30) Console.WriteLine($"{e.Name} ({e.Age} лет)");
    }
}

public record Employee(string Name, int Age, decimal Salary, string Department);