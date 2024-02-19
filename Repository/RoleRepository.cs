using Contracts.Repository;
using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class RoleRepository : RepositoryBase<Role>, IRoleRepository
    {
        public RoleRepository(RepositoryContext repositoryContext) : base(repositoryContext) { }

        public void CreateRole(Role entity)
        {
            Create(entity);
        }

        public void DeleteRole(Role entity)
        {
            Delete(entity);
        }

        public async Task<IEnumerable<Role>> GetAllRoleAsync(bool trackChanges)
        {
            return await FindAll(trackChanges)
            .OrderBy(O => O.Name)
            .ToListAsync();
        }

        public async Task<Role> GetRoleByIdAsync(Guid roleId, bool trackChanges)
        {
            var role = await FindByCondition(role =>
                role.Id.Equals(roleId), trackChanges)
                .FirstOrDefaultAsync() ?? throw new Exception("Role not found");
            return await Task.FromResult(role);
        }

        public void UpdateRole(Role entity)
        {
            Update(entity);
        }
    }
}
