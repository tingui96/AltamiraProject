using Contracts;
using Contracts.Repository;
using Contracts.Services;
using Entities.DTO.Request;
using Entities.DTO.Response;
using Entities.Enum;
using Entities.Exceptions.NotFound;
using Entities.Models;
using Mapster;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.Design;

namespace Services
{
    public class UserService : IUserServices
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly ILoggerManager _loggerManager;
        public UserService(IRepositoryManager repositoryManager,ILoggerManager loggerManager)
        {
            _repositoryManager = repositoryManager;
            _loggerManager = loggerManager;
        }

        public async Task AddRoleToUser(int roleId, int userId)
        {
            var user = await _repositoryManager.Users.GetUserByIdAsync(userId);
            if (user == null) {
                _loggerManager.LogInfo($"User with id: {userId} doesn't exist in the database.");
                throw new UserNotFoundException();
            }
            var role = await _repositoryManager.Roles.GetRoleByIdAsync(roleId);
            if (role == null)
            {
                _loggerManager.LogInfo($"Role with id: {roleId} doesn't exist in the database.");
                throw new RoleNotFoundException();
            }
            user.Role = role;
            _repositoryManager.Users.UpdateUser(user);
            await _repositoryManager.UnitOfWork.SaveChangesAsync();
        }

        public async Task DeleteUserAsync(int id)
        {
            var user = await _repositoryManager.Users.GetUserByIdAsync(id);
            if (user == null)
            {
                _loggerManager.LogInfo($"User with id: {id} doesn't exist in the database.");
                throw new UserNotFoundException();
            }
            if (user.Role.Name == RoleEnum.Administrador.ToString())
            {
                _loggerManager.LogInfo($"Unauthorizated User for delete");
                throw new UserNotFoundException();
            } 
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
            var user = await _repositoryManager.Users.GetUserByIdAsync(userId);
            if (user == null)
            {
                _loggerManager.LogInfo($"User with id: {userId} doesn't exist in the database.");
                throw new UserNotFoundException();
            }
            var result = user.Adapt<UserResponse>();
            return await Task.FromResult(result);
        }

        public async Task<UserResponse> UpdateUserAsync(int userId, UserToUpdateDTO userModel)
        {
            var user = await _repositoryManager.Users.GetUserByIdAsync(userId);
            if (user == null)
            {
                _loggerManager.LogInfo($"User with id: {userId} doesn't exist in the database.");
                throw new UserNotFoundException();
            }
            _repositoryManager.Images.Delete(user.PhotoUrl);
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
            var user = await _repositoryManager.Users.GetUserByIdAsync(request.Id);
            if (user == null)
            {
                _loggerManager.LogInfo($"User with id: {request.Id} doesn't exist in the database.");
                throw new UserNotFoundException();
            }
            if (user.Role.Name == RoleEnum.Administrador.ToString())
            {
                _loggerManager.LogInfo($"Unauthorizated User for Inactive");
                throw new UserNotFoundException();
            }
            user.Activo = request.Active;
            _repositoryManager.Users.UpdateUser(user);
            await _repositoryManager.UnitOfWork.SaveChangesAsync();
        }
        public async Task UpdateUserPhotoAsync(UpdateUserPhoto request)
        {
            var user = await _repositoryManager.Users.GetUserByIdAsync(request.Id);
            if (user == null)
            {
                _loggerManager.LogInfo($"User with id: {request.Id} doesn't exist in the database.");
                throw new UserNotFoundException();
            }
            var result =_repositoryManager.Images.Delete(user.PhotoUrl);
            if (!result)
            {
                _loggerManager.LogInfo($"Error on delete image: {user.PhotoUrl}");
                throw new Exception("error en el delete");
            }
            user.PhotoUrl = request.PhotoUrl;
            _repositoryManager.Users.UpdateUser(user);
            await _repositoryManager.UnitOfWork.SaveChangesAsync();
        }
    }
}
