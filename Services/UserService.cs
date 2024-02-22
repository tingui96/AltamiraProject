using Contracts.Repository;
using Contracts.Services;
using Entities.DTO.Request;
using Entities.DTO.Response;
using Entities.Models;
using Mapster;
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

        public async Task DeleteUserAsync(Guid id)
        {
            var user = await _repositoryManager.Users.FindByIdAsync(id.ToString()) ?? throw new Exception("User not found");
            await _repositoryManager.Users.DeleteAsync(user);
            await _repositoryManager.UnitOfWork.SaveChangesAsync();
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

        public async Task UpdateUserAsync(Guid userId, UserToUpdateDTO userModel)
        {
            var user = await _repositoryManager.Users.FindByIdAsync(userId.ToString()) ?? throw new Exception("User not found");
            var result = userModel.Adapt(user);
            await _repositoryManager.Users.UpdateAsync(result);
            await _repositoryManager.UnitOfWork.SaveChangesAsync();
        }
    }
}
