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
        private readonly IConfiguration _configuration;
        private readonly IAuthService _authRepository;
        private readonly IUserRepository _userRepository;
        public AccountService(IConfiguration configuration, IAuthService authRepository,IUserRepository userRepository)
        {
            _configuration = configuration;
            _authRepository = authRepository;
            _userRepository = userRepository;

        }
        private async Task<List<Claim>> GetClaims(User user)
        {
            var issuer = _configuration.GetSection("Jwt")["Issuer"];
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, user.Email, ClaimValueTypes.Email, issuer),
                new Claim(ClaimTypes.AuthenticationMethod, "bearer", ClaimValueTypes.String, issuer),
                new Claim(ClaimTypes.UserData, user.Id.ToString(), ClaimValueTypes.String, issuer),
            };

            var roles = await _userRepository.GetAllRoles(user.Id);
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role,role));
            }
            return claims;
        }
        private string GetToken(IEnumerable<Claim> claims)
        {
            var issuer = _configuration.GetSection("Jwt")["Issuer"];
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("Jwt")["Key"]));
            var jwt = new JwtSecurityToken(issuer: issuer,
                audience: _configuration.GetSection("Jwt")["Audience"],
                claims: claims,
                notBefore: DateTime.UtcNow,
                expires: DateTime.UtcNow.AddHours(Convert.ToDouble(_configuration.GetSection("Jwt")["AccessTokenExpirationHours"])),
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
            );
            return new JwtSecurityTokenHandler().WriteToken(jwt);
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
