using Application.Repository;
using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Implementation
{
    public class RoleRepository(HotelDbContext context) : IRoleRepository
    {
        public async Task AddRole(Role role)
        {
            await context.Roles.AddAsync(role);
        }

        public void Delete(Guid id)
        {
            var role = context.Roles.FirstOrDefault(r => r.Id == id);
            if (role != null)
            {
                context.Roles.Remove(role);
                context.SaveChanges();
            }
        }

        public bool Exists(string name)
        {
            return context.Roles.Any(r => r.Name == name);
        }

        public async Task<ICollection<Role>> GetAllRole()
        {
            return await context.Roles.ToListAsync();
        }

        public async Task<Role> GetRoleById(Guid id)
        {
            return await context.Roles.FirstOrDefaultAsync(r => r.Id == id);
        }

        public void Update(Role role)
        {
            context.Roles.Update(role);
            context.SaveChanges();
        }
    }
}
