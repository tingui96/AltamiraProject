using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Repository
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllUserAsync(bool trackChanges);
        Task<User> GetUserByIdAsync(Guid UserId, bool trackChanges);
        void CreateUser(User entity);
        void UpdateUser(User entity);
        void DeleteUser(User entity);
    }
}
