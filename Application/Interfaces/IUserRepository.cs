using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Repository
{
    public interface IUserRepository
    {
        Task AddAsync(User user);
        Task<User?> GetUserAsync(Guid id);
        Task<User?> GetUserAsync(string email);
        Task<bool> IsExistsAsync(string email);
    }
}
