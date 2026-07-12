namespace Banking.Core.Models;

public class Account
{
	public int Id { get; private set; }
	public string AccountNumber { get; private set; }
	public int CustomerId { get; private set; }
	public decimal Balance { get; private set; }

	public Account(int id, string accountNumber, int customerId, decimal balance)
	{
		Id = id;
		AccountNumber = accountNumber;
		CustomerId = customerId;
		Balance = balance;
	}
}