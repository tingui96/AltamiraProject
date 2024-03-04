using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Repository
{
    public interface IRoleRepository
    {
        Task<IEnumerable<Role>> GetAllRolesAsync(bool trackChanges = false);
        Task<Role> GetRoleByIdAsync(int roleId, bool trackChanges = false);
        Task<Role> GetRoleByNameAsync(string roleName, bool trackChanges = false);
    }
}
