using Contracts.Repository;
using Contracts.Services;
using Entities.DTO.Request;
using Entities.DTO.Response;
using Entities.Models;
using Mapster;

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
            var user = await _repositoryManager.Users.GetUserByIdAsync(id);
            _repositoryManager.Users.DeleteUser(user);
            await _repositoryManager.UnitOfWork.SaveChangesAsync();
        }

        public async Task<IEnumerable<UserResponse>> GetAllUserAsync()
        {
            var users = await _repositoryManager.Users.GetAllUserAsync();
            var result = users.Adapt<IEnumerable<UserResponse>>();
            return await Task.FromResult(result);
        }

        public async Task<UserResponse> GetUserByIdAsync(Guid userId)
        {
            var user = await _repositoryManager.Users.GetUserByIdAsync(userId);
            var result = user.Adapt<UserResponse>();
            return await Task.FromResult(result);
        }

        public async Task<UserWithDetail> GetUserWithDetailAsync(Guid userId)
        {
            var user = await _repositoryManager.Users.GetUserWithDetailAsync(userId);
            var result = user.Adapt<UserWithDetail>();
            return await Task.FromResult(result);
        }

        public async Task UpdateUserAsync(Guid userId, UserToUpdateDTO userModel)
        {
            var user = await _repositoryManager.Users.GetUserByIdAsync(userId);
            var result = userModel.Adapt(user);
            _repositoryManager.Users.UpdateUser(result);
            await _repositoryManager.UnitOfWork.SaveChangesAsync();
        }
    }
}
