using Microsoft.Data.SqlClient;
using System.Data;

string connectionString = Environment.GetEnvironmentVariable("PRACTICE_DB_CONNECTION") ?? "";

if (string.IsNullOrWhiteSpace(connectionString))
{
    Console.WriteLine("Не задана переменная PRACTICE_DB_CONNECTION.");
    return;
}

try
{
    _ = new SqlConnectionStringBuilder(connectionString);
}
catch (ArgumentException)
{
    Console.WriteLine("Неверная строка подключения.");
    return;
}

while (true)
{
    Console.WriteLine("\n=== PracticeDB ===");
    Console.WriteLine("1. Список сотрудников (задание 28)");
    Console.WriteLine("2. Добавить сотрудника (задание 29)");
    Console.WriteLine("3. Отчёт по отделам (задание 30)");
    Console.WriteLine("0. Выход");
    Console.Write("Выберите действие: ");

    string? choice = Console.ReadLine();
    if (choice == null || choice == "0") break;

    if (choice == "1")
    {
        await ShowEmployees(connectionString);
    }
    else if (choice == "2")
    {
        Console.Write("Имя: ");
        string name = Console.ReadLine()?.Trim() ?? "";

        Console.Write("Зарплата: ");
        bool salaryOk = decimal.TryParse(Console.ReadLine(), out decimal salary);

        Console.Write("Номер отдела: ");
        bool departmentOk = int.TryParse(Console.ReadLine(), out int departmentId);

        if (name.Length == 0 || name.Length > 100 || !salaryOk || salary <= 0 ||
            salary >= 100000000m || decimal.Round(salary, 2) != salary ||
            !departmentOk || departmentId <= 0)
        {
            Console.WriteLine("Неверные данные.");
        }
        else
        {
            await AddEmployee(name, salary, departmentId);
        }
    }
    else if (choice == "3")
    {
        await ShowReport(connectionString);
    }
    else
    {
        Console.WriteLine("Неверный выбор.");
    }
}

static async Task ShowEmployees(string connectionString)
{
    try
    {
        using SqlConnection db = new SqlConnection(connectionString);
        await db.OpenAsync();

        using SqlCommand command = new SqlCommand(
            "SELECT EmployeeName, Salary FROM Employees ORDER BY EmployeeId", db);
        using SqlDataReader reader = await command.ExecuteReaderAsync();

        bool hasRows = false;
        while (await reader.ReadAsync())
        {
            hasRows = true;
            Console.WriteLine(reader.GetString(0) + " — " + reader.GetDecimal(1));
        }

        if (!hasRows)
            Console.WriteLine("Сотрудников нет.");
    }
    catch (SqlException ex)
    {
        Console.WriteLine("Ошибка SQL Server: " + ex.Message);
    }
}

static async Task AddEmployee(string name, decimal salary, int departmentId)
{
    string connection = Environment.GetEnvironmentVariable("PRACTICE_DB_CONNECTION") ?? "";

    try
    {
        using SqlConnection db = new SqlConnection(connection);
        await db.OpenAsync();

        using SqlCommand check = new SqlCommand(
            "SELECT COUNT(*) FROM Employees WHERE EmployeeName = @name", db);
        check.Parameters.Add("@name", SqlDbType.NVarChar, 100).Value = name;

        if (Convert.ToInt32(await check.ExecuteScalarAsync()) > 0)
        {
            Console.WriteLine("Сотрудник с таким именем уже есть.");
            return;
        }

        using SqlCommand insert = new SqlCommand(
            @"INSERT INTO Employees (EmployeeName, Salary, HireDate, DepartmentId)
              OUTPUT INSERTED.EmployeeId
              VALUES (@name, @salary, CAST(GETDATE() AS DATE), @deptId)", db);

        insert.Parameters.Add("@name", SqlDbType.NVarChar, 100).Value = name;
        SqlParameter salaryParam = insert.Parameters.Add("@salary", SqlDbType.Decimal);
        salaryParam.Precision = 10;
        salaryParam.Scale = 2;
        salaryParam.Value = salary;
        insert.Parameters.Add("@deptId", SqlDbType.Int).Value = departmentId;

        int id = Convert.ToInt32(await insert.ExecuteScalarAsync());

        using SqlCommand confirm = new SqlCommand(
            "SELECT EmployeeName, Salary, DepartmentId FROM Employees WHERE EmployeeId = @id", db);
        confirm.Parameters.Add("@id", SqlDbType.Int).Value = id;

        using SqlDataReader reader = await confirm.ExecuteReaderAsync();
        if (await reader.ReadAsync())
        {
            Console.WriteLine("Добавлен сотрудник:");
            Console.WriteLine("ID: " + id);
            Console.WriteLine("Имя: " + reader.GetString(0));
            Console.WriteLine("Зарплата: " + reader.GetDecimal(1));
            Console.WriteLine("Отдел: " + reader.GetInt32(2));
        }
    }
    catch (SqlException ex) when (ex.Number == 547)
    {
        Console.WriteLine("Такого отдела нет.");
    }
    catch (SqlException ex)
    {
        Console.WriteLine("Ошибка SQL Server: " + ex.Message);
    }
}

static async Task ShowReport(string connectionString)
{
    try
    {
        using SqlConnection db = new SqlConnection(connectionString);
        await db.OpenAsync();

        using SqlCommand command = new SqlCommand(
            @"SELECT d.DepartmentName,
                     COUNT(e.EmployeeId) AS EmpCount,
                     AVG(e.Salary) AS AvgSalary
              FROM Departments d
              LEFT JOIN Employees e ON e.DepartmentId = d.DepartmentId
              GROUP BY d.DepartmentName
              ORDER BY d.DepartmentName", db);

        using SqlDataReader reader = await command.ExecuteReaderAsync();
        Console.WriteLine($"{"Отдел",-22} | {"Сотрудников",12} | {"Средняя зарплата",18}");
        Console.WriteLine(new string('-', 60));

        bool found = false;
        while (await reader.ReadAsync())
        {
            found = true;
            string department = reader.GetString(0);
            int count = reader.GetInt32(1);
            string average = reader.IsDBNull(2) ? "N/A" : reader.GetDecimal(2).ToString("F2");

            Console.WriteLine($"{department,-22} | {count,12} | {average,18}");
        }

        if (!found)
            Console.WriteLine("Отделов нет.");
    }
    catch (SqlException ex)
    {
        Console.WriteLine("Ошибка SQL Server: " + ex.Message);
    }
}
