namespace Banking.Core.Models;

public class Transaction
{
    public int Id { get; private set; }
    public TransactionType Type { get; private set; }
    public string? SourceAccountNumber { get; private set; }
    public string? DestinationAccountNumber { get; private set; }
    public decimal Amount { get; private set; }
    public DateTime Timestamp { get; private set; }


    public Transaction(
        int id,
        TransactionType type,
        string? sourceAccountNumber,
        string? destinationAccountNumber,
        decimal amount,
        DateTime timestamp)
    {
        Id = id;
        Type = type;
        SourceAccountNumber = sourceAccountNumber;
        DestinationAccountNumber = destinationAccountNumber;
        Amount = amount;
        Timestamp = timestamp;
    }
}