using CustomersApplication.Shared.Customers;
using Microsoft.AspNetCore.Http;

namespace CustomersApplication.Core.Customers.Interfaces
{
    public interface ICustomerService
    {
        Task<bool> CreateCustomer(IFormCollection collection);
        Task<bool> DeleteCustomer(Guid id, IFormCollection collection);
        Task<bool> EditCustomer(Guid id, IFormCollection collection);
        Task<Customer> GetCustomer(Guid id);
        Task<List<Customer>> GetCustomers();
    }
}
