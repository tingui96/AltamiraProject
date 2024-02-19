using Entities.Models;
using Microsoft.AspNetCore.Identity;
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
        Task<User> GetUserByIdAsync(Guid userId, bool trackChanges);
        void UpdateUser(User entity);
        void DeleteUser(User entity);
        void CreateUser(User entity);
    }
}
