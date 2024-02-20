using Entities.Models;

namespace Contracts.Repository
{
    public interface IRoleRepository
    {
        void CreateRole(Role entity);
        void UpdateRole(Role entity);
        void DeleteRole(Role entity);
        Task<IEnumerable<Role>> GetAllRoleAsync(bool trackChanges = false);
        Task<IEnumerable<Role>> GetRoleByNameAsync(string roleName,bool trackChanges = false);
        Task<Role> GetRoleWithDetailAsync(Guid roleId, bool trackChanges = false);
        Task<Role> GetRoleByIdAsync(Guid roleId, bool trackChanges = false);
    }
}
