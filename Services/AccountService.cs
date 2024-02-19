using Contracts.Repository;
using Contracts.Services;
using Entities.DTO;
using Entities.DTO.Response;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Services
{
    public class AccountService : IAccountService
    {
        private readonly IUserRepository _userRepository;
        public AccountService(IUserRepository userRepository)
        {
            _userRepository = userRepository;

        }
        
        public async Task<AuthResponse> LoginAsync(LoginModel model)
        {
            var user = await _authRepository.Login(model);
            var claims = await GetClaims(user);
            var token = GetToken(claims);
            return new AuthResponse(token);
        }
        public async Task<IdentityResult> RegisterAsync(RegisterModel model)
        {
            var user = await _authRepository.Register(model);
            
            return user;
        }
    }
}
