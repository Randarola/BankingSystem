using Banking.Infrastructure.Repositories;

namespace Banking.Server
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var repository = new CustomerRepository();

            var customers = repository.GetAll();

            foreach (var customer in customers)
            {
                Console.WriteLine($"{customer.Id} {customer.FirstName} {customer.LastName}");
            }
        }
    }
}
