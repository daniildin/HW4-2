using System;
using System.Collections.Generic;

public class BankAccount
{
    // I use this property to hold the unique account ID
    public string AccountId { get; private set; }
    
    // This stores the customer's name (I set it when the account is created)
    public string CustomerName { get; private set; }
    
    // This keeps track of the balance in the account
    public decimal Balance { get; private set; }
    
    // I use this list to store all transaction details (deposits and withdrawals)
    public List<string> Transactions { get; private set; }

    // I set up the account with a customer name and initial balance
    public BankAccount(string customerName, decimal initialBalance)
    {
        // I create a unique account ID using a random number
        AccountId = "ACC" + new Random().Next(100000, 999999).ToString();
        CustomerName = customerName;
        Balance = initialBalance;
        Transactions = new List<string>();
    }

    // This method allows me to deposit money into the account
    public string Deposit(decimal amount)
    {
        if (amount <= 0)
            return "Deposit amount must be greater than zero.";

        Balance += amount;
        Transactions.Add($"Deposited: ${amount}"); // I record the deposit transaction
        return $"Deposited ${amount}. New balance: ${Balance}";
    }

    // This method lets me withdraw money from the account
    public string Withdraw(decimal amount)
    {
        if (amount <= 0)
            return "Withdrawal amount must be greater than zero.";

        if (amount > Balance)
            return "Insufficient funds for withdrawal."; // I check if there's enough money

        Balance -= amount;
        Transactions.Add($"Withdrew: ${amount}"); // I record the withdrawal transaction
        return $"Withdrew ${amount}. New balance: ${Balance}";
    }
}

public class Program
{
    public static void Main()
    {
        // I create a new bank account for a customer "John Doe" with an initial balance of 1000
        BankAccount account = new BankAccount("John Doe", 1000);
        
        // I test the deposit method with a valid deposit
        Console.WriteLine(account.Deposit(500));  // Valid deposit
        Console.WriteLine(account.Deposit(-200)); // Invalid deposit (negative amount)
        
        // I test the withdrawal method with different cases
        Console.WriteLine(account.Withdraw(300));  // Valid withdrawal
        Console.WriteLine(account.Withdraw(2000)); // Invalid withdrawal (insufficient funds)
        Console.WriteLine(account.Withdraw(-100)); // Invalid withdrawal (negative amount)

        // At the end, I display the final balance and list all transactions
        Console.WriteLine($"Final balance: ${account.Balance}");
        Console.WriteLine("Transactions:");
        foreach (var transaction in account.Transactions)
        {
            Console.WriteLine(transaction); // Display each transaction
        }
    }
}
