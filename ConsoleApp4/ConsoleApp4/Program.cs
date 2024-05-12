using System;
using System.Collections.Generic;

class BankAccount
{
    private string accountNumber;
    private string accountHolderName;
    private double balance;

    public BankAccount(string accountNumber, string accountHolderName)
    {
        this.accountNumber = accountNumber;
        this.accountHolderName = accountHolderName;
        this.balance = 0;
    }

    public void Deposit(double amount)
    {
        if (amount <= 0)
        {
            Console.WriteLine("Invalid deposit amount.");
            return;
        }
        balance += amount;
        Console.WriteLine($"Deposited {amount} successfully.");
    }

    public void Withdraw(double amount)
    {
        if (amount <= 0)
        {
            Console.WriteLine("Invalid withdrawal amount.");
            return;
        }
        if (amount > balance)
        {
            Console.WriteLine("Insufficient balance.");
            return;
        }
        balance -= amount;
        Console.WriteLine($"Withdrawn {amount} successfully.");
    }

    public void CheckBalance()
    {
        Console.WriteLine($"Account Balance: {balance}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Dictionary<string, BankAccount> accounts = new Dictionary<string, BankAccount>();

        while (true)
        {
            Console.WriteLine("\nBanking System Menu:");
            Console.WriteLine("1. Create Account");
            Console.WriteLine("2. Deposit Money");
            Console.WriteLine("3. Withdraw Money");
            Console.WriteLine("4. Check Account Balance");
            Console.WriteLine("5. Exit");

            Console.Write("Enter your choice: ");
            int choice;
            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Invalid input. Please enter a number.");
                continue;
            }

            switch (choice)
            {
                case 1:
                    Console.Write("Enter account number: ");
                    string accNumber = Console.ReadLine();
                    Console.Write("Enter account holder name: ");
                    string accHolderName = Console.ReadLine();
                    accounts.Add(accNumber, new BankAccount(accNumber, accHolderName));
                    Console.WriteLine("Account created successfully.");
                    break;
                case 2:
                    Console.Write("Enter account number: ");
                    string accNumDeposit = Console.ReadLine();
                    if (accounts.ContainsKey(accNumDeposit))
                    {
                        Console.Write("Enter deposit amount: ");
                        double depositAmount;
                        if (double.TryParse(Console.ReadLine(), out depositAmount))
                        {
                            accounts[accNumDeposit].Deposit(depositAmount);
                        }
                        else
                        {
                            Console.WriteLine("Invalid deposit amount.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Account not found.");
                    }
                    break;
                case 3:
                    Console.Write("Enter account number: ");
                    string accNumWithdraw = Console.ReadLine();
                    if (accounts.ContainsKey(accNumWithdraw))
                    {
                        Console.Write("Enter withdrawal amount: ");
                        double withdrawAmount;
                        if (double.TryParse(Console.ReadLine(), out withdrawAmount))
                        {
                            accounts[accNumWithdraw].Withdraw(withdrawAmount);
                        }
                        else
                        {
                            Console.WriteLine("Invalid withdrawal amount.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Account not found.");
                    }
                    break;
                case 4:
                    Console.Write("Enter account number: ");
                    string accNumBalance = Console.ReadLine();
                    if (accounts.ContainsKey(accNumBalance))
                    {
                        accounts[accNumBalance].CheckBalance();
                    }
                    else
                    {
                        Console.WriteLine("Account not found.");
                    }
                    break;
                case 5:
                    Console.WriteLine("Exiting...");
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please select a valid option.");
                    break;
            }
        }
    }
}
