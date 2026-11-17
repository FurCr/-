using Practicum.Common;

namespace Practicum.Tasks.Level2;

/// <summary>Задание №30.</summary>
public class Task30_BankAccount : ITask
{
    /// <summary>Название задания.</summary>
    public string Title => "Банковский счёт";
    /// <summary>Описание задания.</summary>
    public string Description => "Пополнение, снятие и собственное исключение.";
    /// <summary>Условия задания.</summary>
    public string[] Requirements => new[]
    {
        "BankAccount с приватным балансом",
        "Deposit и Withdraw",
        "InsufficientFundsException"
    };

    /// <summary>Запускает задание.</summary>
    public void Run()
    {
        BankAccount account = new BankAccount();
        account.Deposit(1000m);
        account.Withdraw(300m);
        Console.WriteLine("Баланс: " + account.Balance);

        try
        {
            account.Withdraw(900m);
        }
        catch (InsufficientFundsException ex)
        {
            Console.WriteLine(ex.Message);
        }

        Console.WriteLine("Баланс после ошибки: " + account.Balance);
    }

    private class BankAccount
    {
        private decimal balance;
        /// <summary>Баланс счёта.</summary>
        public decimal Balance => balance;

        /// <summary>Выполняет действие.</summary>
        public void Deposit(decimal amount)
        {
            if (amount <= 0) throw new ArgumentException("Неверная сумма.");
            balance += amount;
        }

        /// <summary>Выполняет действие.</summary>
        public void Withdraw(decimal amount)
        {
            if (amount <= 0) throw new ArgumentException("Неверная сумма.");
            if (amount > balance) throw new InsufficientFundsException("Недостаточно денег на счёте.");
            balance -= amount;
        }
    }

    private class InsufficientFundsException : Exception
    {
        /// <summary>Выполняет действие.</summary>
        public InsufficientFundsException(string message) : base(message) { }
    }
}
