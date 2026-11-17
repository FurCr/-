using Microsoft.Data.SqlClient;

string connectionString = Environment.GetEnvironmentVariable("PRACTICE_DB_CONNECTION") ?? "";

if (string.IsNullOrWhiteSpace(connectionString))
{
    Console.WriteLine("Не задана переменная PRACTICE_DB_CONNECTION.");
    return;
}

while (true)
{
    Console.WriteLine("\n=== PracticeDB ===");
    Console.WriteLine("1. Список сотрудников (задание 28)");
    Console.WriteLine("0. Выход");
    Console.Write("Выберите действие: ");

    string choice = Console.ReadLine() ?? "";
    if (choice == "0") break;

    if (choice == "1")
        await ShowEmployees(connectionString);
    else
        Console.WriteLine("Неверный выбор.");
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
