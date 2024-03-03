﻿using Entities.DTO.Request;
using Entities.DTO.Response;
using Microsoft.AspNetCore.Identity;

namespace Contracts.Services
{
    public interface IUserServices
    {
        Task<IEnumerable<UserResponse>> GetAllUserAsync();
        Task<UserResponse> GetUserByIdAsync(int userId);
        Task<UserResponse> UpdateUserAsync(int userId, UserToUpdateDTO userModel);
        Task DeleteUserAsync(int id);
        Task AddRoleToUser(int roleId, int userId);
        Task UpdateUserActiveAsync(UpdateUserActiveRequest request);
    }
}
