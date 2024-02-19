using Contracts.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class RoleRepository : IRoleRepository
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        public RoleRepository(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task<IdentityResult> AddRole(IdentityRole role)
        {
            var result = await _roleManager.CreateAsync(role);
            return await Task.FromResult(result);
        }

        public async Task<IdentityResult> DeleteRole(IdentityRole role)
        {
            var result = await _roleManager.DeleteAsync(role);
            return await Task.FromResult(result);
        }

        public async Task<IEnumerable<IdentityRole>> GetAllRole()
        {
            var result = await _roleManager.Roles.OrderBy(x => x.Name).ToListAsync();
            return await Task.FromResult(result);
        }

        public async Task<IdentityRole> GetRoleById(string roleId)
        {
            var result = await _roleManager.FindByIdAsync(roleId) ?? throw new Exception("Role not exist");
            return await Task.FromResult(result);
        }

        public async Task<IdentityResult> UpdateRole(IdentityRole role)
        {
            var result = await _roleManager.UpdateAsync(role);
            return await Task.FromResult(result);
        }
    }
}
