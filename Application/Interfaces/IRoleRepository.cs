using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Repository
{
    public interface IRoleRepository
    {
        Task AddRole(Role role);
        Task<Role> GetRoleById(Guid id);
        Task<ICollection<Role>> GetAllRole();
        void Update(Role role);
        void Delete(Guid id);
        bool Exists(string name);
    }
}
