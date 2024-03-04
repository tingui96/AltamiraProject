using Contracts.Repository;
using Contracts.Services;
using Entities.DTO.Response;
using Entities.Exceptions.NotFound;
using Entities.Models;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class RoleService : IRoleService
    {
        private readonly IRepositoryManager _repositoryManager;
        public RoleService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task<IEnumerable<RoleResponse>> GetAllRoleAsync()
        {
            var roles = await _repositoryManager.Roles.GetAllRolesAsync();
            var result = roles.Adapt<IEnumerable<RoleResponse>>();
            return await Task.FromResult(result);
        }

        public async Task<RoleResponse> GetRoleByIdAsync(int roleId)
        {
            var role = await _repositoryManager.Roles.GetRoleByIdAsync(roleId) ?? throw new RoleNotFoundException();
            var result = role.Adapt<RoleResponse>();
            return await Task.FromResult(result);
        }

        public async Task<RoleResponse> GetRoleByNameAsync(string roleName)
        {
            var role = await _repositoryManager.Roles.GetRoleByNameAsync(roleName) ?? throw new RoleNotFoundException();
            var result = role.Adapt<RoleResponse>();
            return await Task.FromResult(result);
        }
    }
}
