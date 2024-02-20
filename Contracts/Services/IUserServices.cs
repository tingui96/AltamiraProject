﻿using Entities.DTO;
using Entities.DTO.Request;
using Entities.DTO.Response;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Services
{
    public interface IUserServices
    {
        Task<IEnumerable<UserResponse>> GetAllUserAsync();
        Task<UserResponse> GetUserByIdAsync(Guid userId);
        Task<UserWithDetail> GetUserWithDetailAsync(Guid userId);
        Task<UserResponse> GetUserByNameAsync(string name);
        Task UpdateUser(Guid userId, UserToUpdateDTO userModel);
        Task DeleteUserAsync(Guid id);
    }
}
