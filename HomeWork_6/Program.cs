using System;

namespace Program
{
    enum BankCards
    {
        current,
        saving
    }

    class BankAccount
    {
        private static int lastAccountNumber = 0;
        private string accountNumber; 
        private decimal balance;
        private BankCards accountType;

        public string AccountNumber
        {
            get => accountNumber;
        }

        public decimal Balance => balance;


        public BankCards AccountType
        {
            get => accountType;
            set => accountType = value;
        }

        private static string GenerateAccountNumber()
        {
            lastAccountNumber++; 
            return lastAccountNumber.ToString();
        }

        public BankAccount(decimal initialBalance, BankCards type)
        {
            accountNumber = GenerateAccountNumber();
            balance = initialBalance;
            accountType = type;
        }
        public void Deposit(decimal amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine($"Ошибка: сумма пополнения должна быть больше нуля (введено: {amount}).");
                return; 
            }

            balance += amount;
        }

        public void Withdraw(decimal amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine($"Ошибка: сумма снятия должна быть больше нуля (введено: {amount}).");
                return;
            }

            if (amount > balance)
            {
                Console.WriteLine($"Ошибка: недостаточно средств. Запрошено: {amount}, доступно: {balance}.");
                return;
            }

            balance -= amount;
            Console.WriteLine($"Со счета {accountNumber} снято {amount}. Остаток: {balance}");
        }

        public void PrintInfo()
        {
            Console.WriteLine($"Номер счета: {accountNumber}");
            Console.WriteLine($"Баланс: {balance}");
            Console.WriteLine($"Тип счета: {accountType}");
        }
    }

    class HomeworkSix
    {
        public static void Main()
        {
            BankAccount account = new BankAccount(1000m, BankCards.current);
            account.PrintInfo();
            Console.WriteLine();
            account.Withdraw(500m);
            account.Withdraw(2000m);
            account.Withdraw(-100m);
            account.Deposit(10000m);
            account.Withdraw(2000m);
            account.PrintInfo();
            Console.ReadLine();
        }
    }
}