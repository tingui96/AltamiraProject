using Entities.DTO;
using Entities.DTO.Request;
using Entities.DTO.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Services
{
    public interface IRoleService
    {
        Task<IEnumerable<UserResponse>> GetUserInRole(Guid roleId);
        Task<RoleResponse> CreateRoleAsync(RoleModel roleModel);
        Task DeleteRoleAsync(Guid roleId);
        Task<IEnumerable<RoleResponse>> GetAllRolesAsync();
        Task<RoleResponse> GetRoleByIdAsync(Guid roleId);
        Task UpdateRoleAsync(Guid roleId, RoleToUpdate roleModel);
    }
}
