using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CustomersApplication.Shared.Customers;

namespace CustomersApplication.API.Data
{
    public class CustomersApplicationAPIContext : DbContext
    {
        public CustomersApplicationAPIContext (DbContextOptions<CustomersApplicationAPIContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Customer> Customer { get; set; } = default!;
    }
}
