    using Banking.Core.Models;
    using System.Text.Json;

    namespace Banking.Infrastructure.Repositories;

    public class CustomerRepository
    {
        public Customer? GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Customer? GetByPesel(string pesel)
        {
            throw new NotImplementedException();
        }


    public List<Customer> GetAll()
    {
        var json = File.ReadAllText(DataPaths.Customers);

        return JsonSerializer.Deserialize<List<Customer>>(json)!;
    }


    public void Add(Customer customer)
        {
            throw new NotImplementedException();    
        }

        public void Update(Customer customer)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

    }