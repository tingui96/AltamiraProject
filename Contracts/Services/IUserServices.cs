using Entities.DTO;
using Entities.DTO.Request;
using Entities.DTO.Response;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
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
        Task<IdentityResult> UpdateUserAsync(Guid userId, UserToUpdateDTO userModel);
        Task<IdentityResult> DeleteUserAsync(Guid id);
        Task<IdentityResult> AddRoleToUser(Guid roleId, Guid userId);
    }
}
