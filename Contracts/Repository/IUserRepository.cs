using Entities.Models;

namespace Contracts.Repository
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllUserAsync(bool trackChanges = false);
        Task<User> GetUserWithDetailAsync(Guid userId, bool trackChanges = false);
        Task<User> GetUserByIdAsync(Guid userId, bool trackChanges = false);
        Task<User> GetUserByNameAsync(string name, bool trackChanges = false);
        void UpdateUser(User entity);
        void DeleteUser(User entity);
        void CreateUser(User entity);
    }
}
