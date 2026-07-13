using Banking.Core.Models;
using Banking.Infrastructure.Repositories;

namespace Banking.Server.Services;
public class AuthService
{
    private readonly CustomerRepository _customerRepository;
    public AuthService(CustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public Customer? Login(string pesel, string password)
    {
        var customer = _customerRepository.GetByPesel(pesel);

        if (customer == null)
        {
            return null;
        }

        if (customer.PasswordHash != password)
        {
            return null;
        }
        return customer;
    }
}

