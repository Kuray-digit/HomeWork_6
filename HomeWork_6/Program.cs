using Program;
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
        private string accountNumber;
        private decimal balance;
        private BankCards accountType;
        public string AccountNumber
        {
            get { return accountNumber; }
            set { accountNumber = value; }
        }
        public decimal Balance
        {
            get => balance;
            set { if (value >= 0) balance = value; }
        }

        public BankCards AccountType
        {
            get { return accountType; }
            set { accountType = value; }
        }
        public BankAccount(string number, decimal initialBalance, BankCards type)
        {
            accountNumber = number;
            balance = initialBalance;
            accountType = type;
        }
        public BankAccount() { }
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
            BankAccount myAccount = new BankAccount();
            myAccount.AccountNumber = "40817810099910004312";
            myAccount.Balance = 15000.50m;
            myAccount.AccountType = BankCards.current;
            myAccount.PrintInfo();
            Console.ReadLine();
        }
    }
}