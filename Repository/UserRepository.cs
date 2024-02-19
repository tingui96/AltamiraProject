using Contracts.Repository;
using Entities;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<User> _userManager;
        public UserRepository(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IdentityResult> UpdateUser(User entity)
        {
            var result = await _userManager.UpdateAsync(entity);
            return await Task.FromResult(result);
        }
        public async Task<IdentityResult> DeleteUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id) ?? throw new Exception();
            var result = await _userManager.DeleteAsync(user);
            return await Task.FromResult(result);
        }
        /**/
        public async Task<IEnumerable<User>> GetAllUserAsync()
        {
            var users = await _userManager.Users
                .OrderBy(x => x.UserName)
                .ToListAsync();
            return await Task.FromResult(users);
        }
        /**/
        public async Task<User> GetUserByIdAsync(string userId)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Id.Equals(userId)) ?? throw new Exception("User not found");
            return await Task.FromResult(user);
        }

        public async Task<IdentityResult> AddRole(string id, string rol)
        {
            var user = await _userManager.FindByIdAsync(id) ?? throw new Exception();
            var result = await _userManager.AddToRoleAsync(user, rol);

            return await Task.FromResult(result);
        }

        public async Task<IdentityResult> RemoveRole(string id, string rolname)
        {
            var user = await _userManager.FindByIdAsync(id) ?? throw new Exception();
            var result = await _userManager.RemoveFromRoleAsync(user, rolname);

            return await Task.FromResult(result);
        }
        /**/
        public async Task<IEnumerable<User>> GetUsersInRole(string rol)
        {
            var users = await _userManager.GetUsersInRoleAsync(rol);
            return await Task.FromResult(users);
        }
        /**/
        public async Task<IList<string>> GetAllRoles(string id)
        {
            var user = await _userManager.FindByIdAsync(id) ?? throw new Exception("User not found");
            var roles = await _userManager.GetRolesAsync(user);
            return await Task.FromResult(roles);
        }

    }
}
