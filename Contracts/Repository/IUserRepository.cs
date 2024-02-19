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
        Task<IEnumerable<User>> GetAllUserAsync();
        Task<User> GetUserByIdAsync(string userId);
        Task<IdentityResult> AddRole(string id, string rolname);
        Task<IdentityResult> RemoveRole(string id, string rolname);
        Task<IList<string>> GetAllRoles(string id);
        Task<IEnumerable<User>> GetUsersInRole(string rol);
        Task<IdentityResult> UpdateUser(string id, User entity);
        Task<IdentityResult> DeleteUser(string id);
    }
}
