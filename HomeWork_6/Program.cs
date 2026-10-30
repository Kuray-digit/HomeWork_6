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

        public decimal Balance
        {
            get => balance;
            set
            {
                if (value >= 0)
                    balance = value;
            }
        }

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
            BankAccount account1 = new BankAccount(1000m, BankCards.current);
            BankAccount account2 = new BankAccount(5000m, BankCards.saving);
            account1.PrintInfo();
            account2.PrintInfo();
            Console.ReadLine();
        }
    }
}