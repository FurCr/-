using Practicum.Common;

namespace Practicum.Tasks.Level2;

public class Task30_BankAccount : ITask
{
    public string Title => "Банковский счёт";
    public string Description => "Пополнение, снятие и собственное исключение.";
    public string[] Requirements => new[]
    {
        "BankAccount с приватным балансом",
        "Deposit и Withdraw",
        "InsufficientFundsException"
    };

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
        public decimal Balance => balance;

        public void Deposit(decimal amount)
        {
            if (amount <= 0) throw new ArgumentException("Неверная сумма.");
            balance += amount;
        }

        public void Withdraw(decimal amount)
        {
            if (amount <= 0) throw new ArgumentException("Неверная сумма.");
            if (amount > balance) throw new InsufficientFundsException("Недостаточно денег на счёте.");
            balance -= amount;
        }
    }

    private class InsufficientFundsException : Exception
    {
        public InsufficientFundsException(string message) : base(message) { }
    }
}
