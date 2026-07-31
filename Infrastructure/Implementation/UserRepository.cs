using Application.Repository;
using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Implementation
{
    public class UserRepository(HotelDbContext context) : IUserRepository
    {
        public async Task AddAsync(User user)
        {
            await context.Users.AddAsync(user);
        }

        public async Task<User?> GetUserAsync(Guid id)
        {
            return await context.Users.FirstOrDefaultAsync(x => x.Id == id && !x.IsDeleted);
        }

        public async Task<User?> GetUserAsync(string email)
        {
            return await context.Users.FirstOrDefaultAsync(x => x.Email == email && !x.IsDeleted);
        }

        public async Task<bool> IsExistsAsync(string email)
        {
            return await context.Users.AnyAsync(x => x.Email == email);
        }
    }
}

