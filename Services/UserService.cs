using AutoMapper;
using Contracts.Repository;
using Contracts.Services;
using Entities.DTO;
using Entities.DTO.Request;
using Entities.DTO.Response;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class UserService : IUserServices
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        public UserService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
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
            var result = _mapper.Map<IEnumerable<UserResponse>>(users);
            return await Task.FromResult(result);
        }

        public async Task<UserResponse> GetUserByIdAsync(Guid userId)
        {
            var user = await _repositoryManager.Users.GetUserByIdAsync(userId);
            var result = _mapper.Map<UserResponse>(user);
            return await Task.FromResult(result);
        }

        public async Task<UserResponse> GetUserByNameAsync(string name)
        {
            var user = await _repositoryManager.Users.GetUserByNameAsync(name);
            var result = _mapper.Map<UserResponse>(user);
            return await Task.FromResult(result);
        }

        public async Task<UserWithDetail> GetUserWithDetailAsync(Guid userId)
        {
            var user = await _repositoryManager.Users.GetUserWithDetailAsync(userId);
            var result = _mapper.Map<UserWithDetail>(user);
            return await Task.FromResult(result);
        }

        public async Task UpdateUser(Guid userId, UserToUpdateDTO userModel)
        {
            var user = await _repositoryManager.Users.GetUserByIdAsync(userId);
            var result = _mapper.Map(userModel, user);
            _repositoryManager.Users.UpdateUser(user);
            await _repositoryManager.UnitOfWork.SaveChangesAsync();
        }
    }
}
