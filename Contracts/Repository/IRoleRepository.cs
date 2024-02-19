using Entities.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Repository
{
    public interface IRoleRepository
    {
        void CreateRole(Role entity);
        void UpdateRole(Role entity);
        void DeleteRole(Role entity);
        Task<IEnumerable<Role>> GetAllRoleAsync(bool trackChanges);
        Task<Role> GetRoleByIdAsync(Guid roleId, bool trackChanges);
    }
}
