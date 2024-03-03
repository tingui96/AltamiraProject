using Contracts.Repository;
using Entities;
using Entities.Exceptions.NotFound;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class RoleRepository : RepositoryBase<Role> , IRoleRepository
    {
        public RoleRepository(RepositoryContext repositoryContext):base(repositoryContext)
        {
            
        }

        public void CreateRole(Role entity)
        {
            Create(entity);
        }

        public async Task<IEnumerable<Role>> GetAllRolesAsync(bool trackChanges = false)
        {
            return await FindAll(trackChanges)
                .OrderBy(O => O.Name)
                .ToListAsync();
        }

        public async Task<Role> GetRoleByIdAsync(int roleId, bool trackChanges = false)
        {
            var role = await FindByCondition(role =>
                role.Id.Equals(roleId), trackChanges)
                .FirstOrDefaultAsync() ?? throw new RoleNotFoundException();
            return await Task.FromResult(role);
        }

        public async Task<Role> GetRoleByNameAsync(string roleName, bool trackChanges = false)
        {
            var role = await FindByCondition(role =>
                role.Name.Equals(roleName), trackChanges)
                .Include(u => u.Users)
                .ThenInclude(u => u.Role)
                .FirstOrDefaultAsync() ?? throw new RoleNotFoundException();
            return await Task.FromResult(role);
        }
    }
}
