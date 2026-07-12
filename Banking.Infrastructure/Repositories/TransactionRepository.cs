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
        throw new NotImplementedException();
    }

    public void Add(Transaction transaction)
    {
        throw new NotImplementedException();
    }

}