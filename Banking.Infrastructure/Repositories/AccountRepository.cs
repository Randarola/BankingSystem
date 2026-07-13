using Banking.Core.Models;
using System.Text.Json;
namespace Banking.Infrastructure.Repositories;

public class AccountRepository
{
    public Account? GetByAccountNumber(string accountNumber)
    {
        return GetAll().FirstOrDefault( account => account.AccountNumber == accountNumber);
    }

    public Account? GetByCustomerId(int customerId)
    {
        return GetAll().FirstOrDefault( account => account.CustomerId == customerId);
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
        var accounts = GetAll();

        accounts.Add(account);

        var json = JsonSerializer.Serialize(
            accounts,
            new JsonSerializerOptions
            {
                WriteIndented = true
            });

        File.WriteAllText(DataPaths.Accounts, json);

    }

    public void Update(Account account)
    {
        var accounts = GetAll();

        var index = accounts.FindIndex(
            a => a.AccountNumber == account.AccountNumber);

        if (index == -1)
        {
            return;
        }

        accounts[index] = account;

        var json = JsonSerializer.Serialize(
            accounts,
            new JsonSerializerOptions
            {
                WriteIndented = true
            });

        File.WriteAllText(DataPaths.Accounts, json);

    }

}