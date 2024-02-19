using Entities.DTO;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Services
{
    public interface IAuthService
    {
        Task<IdentityResult> Register(RegisterModel model);
        Task<User> Login(LoginModel model);
        //Task<IdentityResult> ChangePassword(ChangePasswordModel model);
        //Task<IdentityResult> SetPassword(SetPasswordModel model);
        //Task<IdentityResult> ResetPassword(ResetPasswordModel model);
        //void ForgotPassword(ForgotPasswordModel model);

    }
}
