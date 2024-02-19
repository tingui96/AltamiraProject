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
        Task<IdentityResult> AddRole(IdentityRole role);
        Task<IdentityResult> UpdateRole(IdentityRole role);
        Task<IdentityResult> DeleteRole(IdentityRole role);
        Task<IEnumerable<IdentityRole>> GetAllRole();
        Task<IdentityRole> GetRoleById(string roleId);
    }
}
