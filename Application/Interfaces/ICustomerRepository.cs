using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Repository
{
    public interface ICustomerRepository
    {
        Task CreateCustomer(Customer customer);
        Task<ICollection<Customer>> GetAllCustomersAsync();
        Task<Customer?> GetCustomerAsync(string email);
        void Update(Customer customer);
        void DeleteCustomer(Guid id);
    }
}
