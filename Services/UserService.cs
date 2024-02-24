using Contracts.Repository;
using Contracts.Services;
using Entities.DTO.Request;
using Entities.DTO.Response;
using Entities.Models;
using Mapster;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Services
{
    public class UserService : IUserServices
    {
        private readonly IRepositoryManager _repositoryManager;
        public UserService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task<IdentityResult> AddRoleToUser(Guid roleId, Guid userId)
        {
            var user = await _repositoryManager.Users.FindByIdAsync(userId.ToString()) ?? throw new Exception("User not found");
            var role = await _repositoryManager.Roles.FindByIdAsync(roleId.ToString()) ?? throw new Exception("Role not found");
            var result = await _repositoryManager.Users.AddToRoleAsync(user, role.NormalizedName);
            return await Task.FromResult(result);
        }

        public async Task<IdentityResult> DeleteUserAsync(Guid id)
        {
            var user = await _repositoryManager.Users.FindByIdAsync(id.ToString()) ?? throw new Exception("User not found");
            var result  = await _repositoryManager.Users.DeleteAsync(user);
            await _repositoryManager.UnitOfWork.SaveChangesAsync();
            return await Task.FromResult(result);
        }

        public async Task<IEnumerable<UserResponse>> GetAllUserAsync()
        {
            var users = await _repositoryManager.Users.Users.ToListAsync();
            var result = users.Adapt<IEnumerable<UserResponse>>();
            return await Task.FromResult(result);
        }

        public async Task<UserResponse> GetUserByIdAsync(Guid userId)
        {
            var user = await _repositoryManager.Users.FindByIdAsync(userId.ToString()) ?? throw new Exception("User not found");
            var result = user.Adapt<UserResponse>();
            return await Task.FromResult(result);
        }

        public async Task<IdentityResult> UpdateUserAsync(Guid userId, UserToUpdateDTO userModel)
        {
            var user = await _repositoryManager.Users.FindByIdAsync(userId.ToString()) ?? throw new Exception("User not found");
            var userToUpdate = userModel.Adapt(user);
            var result = await _repositoryManager.Users.UpdateAsync(userToUpdate);
            await _repositoryManager.UnitOfWork.SaveChangesAsync();
            return await Task.FromResult(result);
        }
    }
}
