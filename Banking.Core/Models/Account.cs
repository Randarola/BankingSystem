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
}