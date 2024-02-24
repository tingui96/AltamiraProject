using Contracts.Repository;
using Contracts.Services;
using CryptoHelper;
using Entities.DTO;
using Entities.DTO.Response;
using Entities.Models;
using Mapster;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Services
{
    public class AuthService : IAuthService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IConfiguration _configuration;

        public AuthService(IRepositoryManager repositoryManager, IConfiguration configuration)
        {
            _repositoryManager = repositoryManager;
            _configuration = configuration;
        }  

        public async Task<AuthResponse> LoginAsync(LoginModel model)
        {
            var userToVerify = await UserExists(model.Usuario);
            if (!userToVerify.Activo) throw new Exception("User inactive"); 
            var check = await _repositoryManager.Users.CheckPasswordAsync(userToVerify, model.Password);
            if (check)
            {
                var claims = await GetClaims(userToVerify);
                var token = GetToken(claims);
                return new AuthResponse(token);
            }
            throw new Exception("Wrong password");
        }

        public async Task<UserResponse> RegisterAsync(RegisterModel model)
        {
            var user = model.Adapt<User>();
            await _repositoryManager.Users.CreateAsync(user,model.Password); 
            await _repositoryManager.UnitOfWork.SaveChangesAsync();
            var result = user.Adapt<UserResponse>();
            return await Task.FromResult(result);
        }

        private async Task<User> UserExists(string Username)
        {
            var user = await _repositoryManager.Users.FindByNameAsync(Username) ?? throw new Exception("User not exist");
            return await Task.FromResult(user);
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

            var roles = await _repositoryManager.Users.GetRolesAsync(user);            
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
    }       
}
