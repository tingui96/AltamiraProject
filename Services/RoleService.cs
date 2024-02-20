using Contracts.Repository;
using Contracts.Services;
using Entities.DTO;
using Entities.DTO.Request;
using Entities.DTO.Response;
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
        public async Task<IEnumerable<UserResponse>> GetUserInRole(Guid roleId)
        {
            var role = await _repositoryManager.Roles.GetRoleWithDetailAsync(roleId);
            var users = role.Users;
            var result = users.Adapt<IEnumerable<UserResponse>>();
            return await Task.FromResult(result);
        }
        public async Task<RoleResponse> CreateRoleAsync(RoleModel roleModel)
        {
            var role = await _repositoryManager.Roles.GetRoleByNameAsync(roleModel.Name);
            if(!role.Any())
            {
                var newRole = roleModel.Adapt<Role>();
                _repositoryManager.Roles.CreateRole(newRole);
                await _repositoryManager.UnitOfWork.SaveChangesAsync();
                var result = newRole.Adapt<RoleResponse>();
                return await Task.FromResult(result);
            }
            throw new Exception("This role already exists");
        }

        public async Task DeleteRoleAsync(Guid roleId)
        {
            var role = await _repositoryManager.Roles.GetRoleByIdAsync(roleId);
            _repositoryManager.Roles.DeleteRole(role);
            await _repositoryManager.UnitOfWork.SaveChangesAsync();
        }

        public async Task<IEnumerable<RoleResponse>> GetAllRolesAsync()
        {
            var roles = await _repositoryManager.Roles.GetAllRoleAsync();
            var result = roles.Adapt<IEnumerable<RoleResponse>>();
            return await Task.FromResult(result);
        }

        public async Task<RoleResponse> GetRoleByIdAsync(Guid roleId)
        {
            var role = await _repositoryManager.Roles.GetRoleByIdAsync(roleId);
            var result = role.Adapt<RoleResponse>();
            return await Task.FromResult(result);
        }

        public async Task UpdateRoleAsync(Guid roleId, RoleToUpdate roleModel)
        {
            var role = await _repositoryManager.Roles.GetRoleByIdAsync(roleId);
            var result = roleModel.Adapt(role);
            _repositoryManager.Roles.UpdateRole(result);
            await _repositoryManager.UnitOfWork.SaveChangesAsync();
        }
    }
}
