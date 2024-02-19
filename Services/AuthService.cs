using Contracts.Services;
using Entities.DTO;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AuthService(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public async Task<IdentityResult> AddRole(IdentityRole role)
        {
            var rol = await _roleManager.CreateAsync(role);
            return await Task.FromResult(rol);
        }  

        public async Task<User> Login(LoginModel model)
        {
            var userToVerify = await UserExists(model.Usuario);
            var check = await _userManager.CheckPasswordAsync(userToVerify, model.Password);
            if (check) return await Task.FromResult(userToVerify);
            throw new Exception();
        }

        public async Task<IdentityResult> Register(RegisterModel model)
        {
            var user = new User() { Name = model.Name, UserName = model.UserName, Email = model.Email, Activo = true };

            var result = await _userManager.CreateAsync(user, model.Password);
            if(!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    throw new Exception(error.Description);
                }
            }
            return await Task.FromResult(result);
        }

        private async Task<User> UserExists(string Username)
        {
            var user = await _userManager.FindByNameAsync(Username) ?? throw new Exception("User not exist");
            return await Task.FromResult(user);
        }
    }
}
