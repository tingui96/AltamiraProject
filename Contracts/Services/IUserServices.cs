using Entities.DTO.Request;
using Entities.DTO.Response;
using Entities.RequestFeatures;

namespace Contracts.Services
{
    public interface IUserServices
    {
        Task<PagedList<UserResponse>> GetAllUserAsync(UserParameters userParameters);
        Task<UserResponse> GetUserByIdAsync(int userId);
        Task<UserResponse> UpdateUserAsync(int userId, UserToUpdateDTO userModel);
        Task DeleteUserAsync(int id);
        Task AddRoleToUser(int roleId, int userId);
        Task UpdateUserActiveAsync(UpdateUserActiveRequest request);
        Task UpdateUserPhotoAsync(UpdateUserPhoto request);
    }
}
