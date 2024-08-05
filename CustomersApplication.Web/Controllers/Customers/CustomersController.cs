using CustomersApplication.Core.Customers.Interfaces;
using CustomersApplication.Shared.Customers;
using CustomersApplication.Web.Models;
using CustomersApplication.Web.Models.Customers;
using Microsoft.AspNetCore.Mvc;

namespace CustomersApplication.Web.Controllers.Customers
{
    public class CustomersController : Controller
    {
        private readonly ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        // GET: CustomersController
        public async Task<ActionResult> Index()
        {
            try
            {
                // Get the list of customers and send to page.
                List<Customer> customers = await _customerService.GetCustomers();

                // Map result to view model. Ideally this can be done with AutoMapper.
                var customersViewModel = customers?.Select(customer => new CustomerViewModel()
                {
                    Id = customer.Id,
                    Name = customer.Name,
                    Email = customer.Email,
                    PhoneNumber = customer.PhoneNumber,
                    Address = customer.Address
                }).ToList() ?? new List<CustomerViewModel>();

                return View("~/Views/Customers/List.cshtml", customersViewModel);
            }
            catch (Exception ex)
            {
                // log error
                return View("~/Views/Shared/Error.cshtml", new ErrorViewModel());
            }

        }

        // GET: CustomersController/Details/5
        public async Task<ActionResult> Details(Guid id)
        {
            try
            {
                // Get the list of customers and send to page.
                Customer customer = await _customerService.GetCustomer(id);

                // Map result to view model. Ideally this can be done with AutoMapper.
                var customerViewModel = new CustomerViewModel()
                {
                    Id = customer.Id,
                    Name = customer.Name,
                    Email = customer.Email,
                    PhoneNumber = customer.PhoneNumber,
                    Address = customer.Address
                };

                return View(customerViewModel);
            }
            catch (Exception ex)
            {
                // log error
                return View("~/Views/Shared/Error.cshtml", new ErrorViewModel());
            }
        }

        // GET: CustomersController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CustomersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(IFormCollection collection)
        {
            try
            {
                bool createSuccessful = await _customerService.CreateCustomer(collection);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                // log error
                return View("~/Views/Shared/Error.cshtml", new ErrorViewModel());
            }
        }

        // GET: CustomersController/Edit/5
        public async Task<ActionResult> Edit(Guid id)
        {
            try
            {
                // Get the list of customers and send to page.
                Customer customer = await _customerService.GetCustomer(id);

                // Map result to view model. Ideally this can be done with AutoMapper.
                var customerViewModel = new CustomerViewModel()
                {
                    Id = customer.Id,
                    Name = customer.Name,
                    Email = customer.Email,
                    PhoneNumber = customer.PhoneNumber,
                    Address = customer.Address
                };

                return View(customerViewModel);
            }
            catch (Exception ex)
            {
                // log error
                return View("~/Views/Shared/Error.cshtml", new ErrorViewModel());
            }
        }

        // POST: CustomersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Guid id, IFormCollection collection)
        {
            try
            {
                bool editSuccessful = await _customerService.EditCustomer(id, collection);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                // log error
                return View("~/Views/Shared/Error.cshtml", new ErrorViewModel());
            }
        }

        // GET: CustomersController/Delete/5
        public async Task<ActionResult> Delete(Guid id)
        {
            try
            {
                // Get the list of customers and send to page.
                Customer customer = await _customerService.GetCustomer(id);

                // Map result to view model. Ideally this can be done with AutoMapper.
                var customerViewModel = new CustomerViewModel()
                {
                    Id = customer.Id,
                    Name = customer.Name,
                    Email = customer.Email,
                    PhoneNumber = customer.PhoneNumber,
                    Address = customer.Address
                };

                return View(customerViewModel);
            }
            catch (Exception ex)
            {
                // log error
                return View("~/Views/Shared/Error.cshtml", new ErrorViewModel());
            }
        }

        // POST: CustomersController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(Guid id, IFormCollection collection)
        {
            try
            {
                bool deleteSuccessful = await _customerService.DeleteCustomer(id, collection);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                // log error
                return View("~/Views/Shared/Error.cshtml", new ErrorViewModel());
            }
        }
    }
}
