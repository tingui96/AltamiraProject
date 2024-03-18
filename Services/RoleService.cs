using Contracts;
using Contracts.Repository;
using Contracts.Services;
using Entities.DTO.Response;
using Entities.Exceptions.NotFound;
using Mapster;

namespace Services
{
    public class RoleService : IRoleService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly ILoggerManager _loggerManager;
        public RoleService(IRepositoryManager repositoryManager, ILoggerManager loggerManager)
        {
            _repositoryManager = repositoryManager;
            _loggerManager = loggerManager;
        }

        public async Task<IEnumerable<RoleResponse>> GetAllRoleAsync()
        {
            var roles = await _repositoryManager.Roles.GetAllRolesAsync();
            var result = roles.Adapt<IEnumerable<RoleResponse>>();
            return await Task.FromResult(result);
        }

        public async Task<RoleResponse> GetRoleByIdAsync(int roleId)
        {
            var role = await _repositoryManager.Roles.GetRoleByIdAsync(roleId);
            if (role == null)
            {
                _loggerManager.LogInfo($"Role with id: {roleId} doesn't exist in the database.");
                throw new RoleNotFoundException();
            }
            var result = role.Adapt<RoleResponse>();
            return await Task.FromResult(result);
        }

        public async Task<RoleResponse> GetRoleByNameAsync(string roleName)
        {
            var role = await _repositoryManager.Roles.GetRoleByNameAsync(roleName);
            if (role == null)
            {
                _loggerManager.LogInfo($"Role with roleName: {roleName} doesn't exist in the database.");
                throw new RoleNotFoundException();
            }
            var result = role.Adapt<RoleResponse>();
            return await Task.FromResult(result);
        }
    }
}
