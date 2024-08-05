using CustomersApplication.Core.Customers.Interfaces;
using CustomersApplication.Core.WebApi.Interfaces;
using CustomersApplication.Shared.Customers;
using Microsoft.AspNetCore.Http;

namespace CustomersApplication.Buisness.Customers
{
    public class CustomerService : ICustomerService
    {
        private readonly IWebApiService _webApiService;

        public CustomerService(IWebApiService webApiService)
        {
            _webApiService = webApiService;
        }

        public async Task<bool> CreateCustomer(IFormCollection collection)
        {
            var customer = ConvertToCustomer(collection);
            var response = await _webApiService.PostAsync<Customer, Customer>("customers", customer);
            return response != null && !response.Id.Equals(Guid.Empty);
        }

        public async Task<bool> DeleteCustomer(Guid id, IFormCollection collection)
        {
            var successfull = await _webApiService.DeleteAsync<bool>($"customers/{id}");
            return successfull;
        }

        public async Task<bool> EditCustomer(Guid id, IFormCollection collection)
        {
            var customer = ConvertToCustomer(collection);
            var successfull = await _webApiService.PutAsync<Customer, bool>($"customers/{id}", customer);
            return successfull;
        }

        public async Task<Customer> GetCustomer(Guid id)
        {
            var customer = await _webApiService.GetAsync<Customer>($"customers/{id}");
            return customer;
        }

        public async Task<List<Customer>> GetCustomers()
        {
            var customers = await _webApiService.GetAsync<List<Customer>>("customers");
            return customers;
        }

        private Customer ConvertToCustomer(IFormCollection collection)
        {
            Guid.TryParse(collection["Id"], out Guid customerId);
            var customer = new Customer()
            {
                Id = customerId,
                Name = collection["Name"],
                Email = collection["Email"],
                PhoneNumber = collection["PhoneNumber"],
                Address = collection["Address"]
            };
            return customer;
        }
    }
}
