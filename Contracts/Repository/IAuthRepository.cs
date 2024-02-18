using Entities.DTO;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Repository
{
    public interface IAuthRepository
    {
        Task<IdentityResult> Register(RegisterModel model);
        Task<User> Login(LoginModel model);
        Task<IdentityResult> AddRole(IdentityRole role);
        //Task<IdentityResult> ChangePassword(ChangePasswordModel model);
        //Task<IdentityResult> SetPassword(SetPasswordModel model);
        //Task<IdentityResult> ResetPassword(ResetPasswordModel model);
        //void ForgotPassword(ForgotPasswordModel model);
        Task<IList<string>> GetAllRoles(User user);
        Task<IdentityResult> AddRole(string id, string rolname);
        Task<IdentityResult> RemoveRole(string id, string rolname);
        Task<IEnumerable<User>> GetUsersInRole(string rol);
    }
}
