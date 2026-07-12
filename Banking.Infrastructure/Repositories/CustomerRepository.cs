using Banking.Core.Models;
using System.Text.Json;
using System.Linq;

namespace Banking.Infrastructure.Repositories;

public class CustomerRepository
{
    public Customer? GetById(int id)
    {
       return GetAll().FirstOrDefault(customer => customer.Id == id);
    }

    public Customer? GetByPesel(string pesel)
    {
        return GetAll().FirstOrDefault(customer => customer.Pesel == pesel);
    }


    public List<Customer> GetAll()
    {
        var json = File.ReadAllText(DataPaths.Customers);

        return JsonSerializer.Deserialize<List<Customer>>(json)!;
    }


    public void Add(Customer customer)
    {

        var customers = GetAll();

        customers.Add(customer);

        var json = JsonSerializer.Serialize(
            customers,
            new JsonSerializerOptions
            {
                WriteIndented = true
            });

        File.WriteAllText(DataPaths.Customers, json);

    }

    public void Update(Customer customer)
    {

        var customers = GetAll();

        var index = customers.FindIndex(c => c.Id == customer.Id);

        if (index == -1)
        {
            return;
        }

        customers[index] = customer;

        var json = JsonSerializer.Serialize(
            customers,
            new JsonSerializerOptions
            {
                WriteIndented = true
            });

        File.WriteAllText(DataPaths.Customers, json);
    }


    public void Delete(int id)
    {
        throw new NotImplementedException();
    }

}