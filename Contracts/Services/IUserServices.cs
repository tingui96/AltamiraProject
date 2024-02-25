using Entities.DTO.Request;
using Entities.DTO.Response;
using Microsoft.AspNetCore.Identity;

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
