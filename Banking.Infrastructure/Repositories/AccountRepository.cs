using Banking.Core.Models;
using System.Text.Json;
namespace Banking.Infrastructure.Repositories;

public class AccountRepository
{
    public Account? GetByAccountNumber(string accountNumber)
    {
        throw new NotImplementedException();
    }

    public Account? GetByCustomerId(int customerId)
    {
        throw new NotImplementedException();
    }

    public List<Account> GetAll()
    {

        var json = File.ReadAllText(DataPaths.Accounts);

        return JsonSerializer.Deserialize<List<Account>>(
            json,
            new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            })
            ?? [];
    }

    public void Add(Account account)
    {
        throw new NotImplementedException();
    }

    public void Update(Account account)
    {
        throw new NotImplementedException();
    }

}