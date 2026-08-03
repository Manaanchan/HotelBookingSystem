using Application.Repository;
using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Infrastructure.Implementation
{
    public class CustomerRepository(HotelDbContext context) : ICustomerRepository
    {
        public async Task CreateCustomer(Customer customer)
        {
            await context.Customers.AddAsync(customer);
        }

        public async Task<Customer?> GetCustomerAsync(string email)
        {
            return await context.Customers.FirstOrDefaultAsync(x => x.Email == email);
        }

        public async Task<ICollection<Customer>> GetAllCustomersAsync()
        {
            return await context.Customers.ToListAsync();
        }

        public async Task Update(Customer customer)
        {
            context.Customers.Update(customer);
             await context.SaveChangesAsync();
        }

        public void DeleteCustomer(Guid id)
        {
            var customer = context.Customers.FirstOrDefault(r => r.Id == id);
            if (customer != null)
            {
                context.Customers.Remove(customer);
                context.SaveChanges();
            }
        }
    }
}



