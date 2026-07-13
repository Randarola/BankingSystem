namespace Banking.Core.Models;

public class Account
{
	public string AccountNumber { get; private set; }
	public int CustomerId { get; private set; }
	public decimal Balance { get; private set; }

	public Account(string accountNumber, int customerId, decimal balance)
	{
		AccountNumber = accountNumber;
		CustomerId = customerId;
		Balance = balance;
	}

	public void Deposit(decimal amount)
    {
        if (amount <= 0)
        {
            throw new ArgumentException("Deposit amount must be greater than zero.");
        }
        Balance += amount;
    }

	public bool Withdraw(decimal amount)
    {
        if (amount <= 0)
        {
            throw new ArgumentException("Withdrawal amount must be greater than zero.");
        }
        if (Balance >= amount)
        {
            Balance -= amount;
            return true;
        }
        return false; // Insufficient funds
    }
}