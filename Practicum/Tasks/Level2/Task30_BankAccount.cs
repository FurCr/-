using System;
using System.Collections.Generic;
using System.Text;

using Practicum.Common;

namespace Practicum.Tasks.Level2;

/// <summary>Задание 30. BankAccount + свой Exception.</summary>
public class Task30_BankAccount : ITask
{
    public string Title => "BankAccount + свой Exception";
    public string Description => "Реализовать банковский счёт с собственным исключением.";
    public string[] Requirements => new[]
    {
        "Класс BankAccount с приватным балансом",
        "Методы Deposit(decimal), Withdraw(decimal)",
        "Свой класс InsufficientFundsException : Exception",
        "Withdraw бросает исключение, если сумма больше баланса",
        "Продемонстрировать: успешное снятие и попытку снять больше баланса (с try/catch)"
    };

    public void Run()
    {
        var account = new BankAccount(1000m);

        account.Deposit(500m);
        Console.WriteLine($"Баланс после пополнения: {account.Balance}");

        try
        {
            account.Withdraw(2000m);
        }
        catch (InsufficientFundsException ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }

        Console.WriteLine($"Итоговый баланс: {account.Balance}");
    }
}

public class InsufficientFundsException : Exception
{
    public InsufficientFundsException(string message) : base(message) { }
}

public class BankAccount
{
    public decimal Balance { get; private set; }

    public BankAccount(decimal initialBalance)
    {
        Balance = initialBalance;
    }

    public void Deposit(decimal amount)
    {
        if (amount <= 0) throw new ArgumentException("Сумма пополнения должна быть больше нуля");
        Balance += amount;
    }

    public void Withdraw(decimal amount)
    {
        if (amount > Balance)
            throw new InsufficientFundsException($"Недостаточно средств. Баланс: {Balance}, Запрошено: {amount}");

        Balance -= amount;
    }
}