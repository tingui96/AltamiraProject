using Entities.DTO.Response;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Services
{
    public interface IRoleService
    {
        Task<IEnumerable<RoleResponse>> GetAllRoleAsync();
        Task<RoleResponse> GetRoleByIdAsync(int roleId);
        Task<RoleResponse> GetRoleByNameAsync(string roleName);
    }
}
