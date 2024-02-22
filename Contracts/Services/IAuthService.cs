using Entities.DTO;
using Entities.DTO.Response;
using Entities.Models;

namespace Contracts.Services
{
    public interface IAuthService
    {
        Task<UserResponse> RegisterAsync(RegisterModel model);
        Task<AuthResponse> LoginAsync(LoginModel model);
        //Task<IdentityResult> ChangePassword(ChangePasswordModel model);
        //Task<IdentityResult> SetPassword(SetPasswordModel model);
        //Task<IdentityResult> ResetPassword(ResetPasswordModel model);
        //void ForgotPassword(ForgotPasswordModel model);

    }
}
