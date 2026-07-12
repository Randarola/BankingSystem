using Banking.Core.Models;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Banking.Infrastructure.Repositories;

public class TransactionRepository
{
    public List<Transaction> GetAll()
    {

        var json = File.ReadAllText(DataPaths.Transactions);
      
        return JsonSerializer.Deserialize<List<Transaction>>(
            json,
            new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                Converters =
                {
            new JsonStringEnumConverter()
                }
            })
            ?? [];
    }

    public List<Transaction> GetByAccountNumber(string accountNumber)
    {
        return GetAll().Where(transaction => transaction.SourceAccountNumber == accountNumber || transaction.DestinationAccountNumber == accountNumber).ToList();
    }

    public void Add(Transaction transaction)
    {
        throw new NotImplementedException();
    }

}