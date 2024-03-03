using Contracts.Repository;
using Contracts.Services;
using Entities.DTO.Request;
using Entities.DTO.Response;
using Entities.Enum;
using Entities.Exceptions.NotFound;
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

        public async Task AddRoleToUser(int roleId, int userId)
        {
            var user = await _repositoryManager.Users.GetUserByIdAsync(userId) ?? throw new UserNotFoundException();
            var role = await _repositoryManager.Roles.GetRoleByIdAsync(roleId) ?? throw new UserNotFoundException();
            user.Role = role;
            await _repositoryManager.UnitOfWork.SaveChangesAsync();
        }

        public async Task DeleteUserAsync(int id)
        {
            var user = await _repositoryManager.Users.GetUserByIdAsync(id) ?? throw new UserNotFoundException();
            _repositoryManager.Users.DeleteUser(user);
            await _repositoryManager.UnitOfWork.SaveChangesAsync();
        }

        public async Task<IEnumerable<UserResponse>> GetAllUserAsync()
        {
            var users = await _repositoryManager.Users.GetAllUsersAsync();
            var result = users.Adapt<IEnumerable<UserResponse>>();
            return await Task.FromResult(result);
        }

        public async Task<UserResponse> GetUserByIdAsync(int userId)
        {
            var user = await _repositoryManager.Users.GetUserByIdAsync(userId) ?? throw new UserNotFoundException();
            var result = user.Adapt<UserResponse>();
            return await Task.FromResult(result);
        }

        public async Task<UserResponse> UpdateUserAsync(int userId, UserToUpdateDTO userModel)
        {
            var user = await _repositoryManager.Users.GetUserByIdAsync(userId) ?? throw new UserNotFoundException();
            var userToUpdate = userModel.Adapt(user);
            _repositoryManager.Users.UpdateUser(userToUpdate);
            await _repositoryManager.UnitOfWork.SaveChangesAsync();
            var result = userToUpdate.Adapt<UserResponse>();
            return await Task.FromResult(result);
        }
        public async Task<IEnumerable<UserResponse>> GetAllArtistAsync()
        {
            var role = await _repositoryManager.Roles.GetRoleByNameAsync(RoleEnum.Artist.ToString());
            var artists = role.Users;
            var result = artists.Adapt<IEnumerable<UserResponse>>();
            return await Task.FromResult(result);
        }
        public async Task UpdateUserActiveAsync(UpdateUserActiveRequest request)
        {
            var user = await _repositoryManager.Users.GetUserByIdAsync(request.Id) ?? throw new UserNotFoundException();
            user.Activo = request.Active;
            _repositoryManager.Users.UpdateUser(user);
            await _repositoryManager.UnitOfWork.SaveChangesAsync();
        }
    }
}
