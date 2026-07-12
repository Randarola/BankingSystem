using System;

public class Customer
{
    public int Id { get; private set; }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string Pesel { get; private set; }
    public string PasswordHash { get; private set; }

    public Customer(int id, string firstName, string lastName, string pesel, string passwordHash)
	{
        Id = id;
		FirstName = firstName;
        LastName = lastName;
        Pesel = pesel;
        PasswordHash = passwordHash;
	}
	
}
