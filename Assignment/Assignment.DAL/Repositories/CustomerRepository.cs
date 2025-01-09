using Assignment.DAL.Interfaces;
using Assignment.DM.Models;

public class CustomerRepository : ICustomerRepository
{
    private readonly List<Customer> _customers = new()
    {
        new Customer { CustomerId = 1, Name = "Alice Johnson", Email = "alice.johnson@example.com", PhoneNumber = "123-456-7890", Address = "123 Maple St, Springfield", DateRegistered = DateTime.Parse("2023-04-12") },
        new Customer { CustomerId = 2, Name = "Bob Williams", Email = "bob.williams@example.com", PhoneNumber = "987-654-3210", Address = "456 Oak St, Springfield", DateRegistered = DateTime.Parse("2023-05-25") }
    };
    public Task<IEnumerable<Customer>> GetAllCustomersAsync() => Task.FromResult((IEnumerable<Customer>)_customers);
    public Task<Customer> GetCustomerByIdAsync(int id) => Task.FromResult(_customers.FirstOrDefault(c => c.CustomerId == id));
    public Task<Customer> CreateCustomerAsync(Customer customer)
    {
        customer.CustomerId = _customers.Max(c => c.CustomerId) + 1;
        _customers.Add(customer);
        return Task.FromResult(customer);
    }
    public Task<Customer> UpdateCustomerAsync(int id, Customer updatedCustomer)
    {
        var customer = _customers.FirstOrDefault(c => c.CustomerId == id);
        if (customer == null) return Task.FromResult<Customer>(null);
        customer.Name = updatedCustomer.Name;
        customer.Email = updatedCustomer.Email;
        customer.PhoneNumber = updatedCustomer.PhoneNumber;
        customer.Address = updatedCustomer.Address;
        customer.DateRegistered = updatedCustomer.DateRegistered;
        return Task.FromResult(customer);
    }
    public Task<bool> DeleteCustomerAsync(int id)
    {
        var customer = _customers.FirstOrDefault(c => c.CustomerId == id);
        if (customer == null) return Task.FromResult(false);
        _customers.Remove(customer);
        return Task.FromResult(true);
    }
}