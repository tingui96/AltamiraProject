using AutoMapper;
using Contracts.Repository;
using Contracts.Services;
using CryptoHelper;
using Entities.DTO;
using Entities.DTO.Response;
using Entities.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Repository;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Services
{
    public class AuthService : IAuthService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public AuthService(IRepositoryManager repositoryManager, IMapper mapper, IConfiguration configuration)
        {
            _repositoryManager = repositoryManager;
            _configuration = configuration;
            _mapper = mapper;
        }  

        public async Task<AuthResponse> LoginAsync(LoginModel model)
        {
            var userToVerify = await UserExists(model.Usuario);
            var check = CheckPassword(userToVerify, model.Password);
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
            var user = _mapper.Map<User>(model);
            user.Password = HashPassword(model.Password);
            _repositoryManager.Users.CreateUser(user); 
            var result = _mapper.Map<UserResponse>(user);
            return await Task.FromResult(result);
        }

        private async Task<User> UserExists(string Username)
        {
            var user = await _repositoryManager.Users.GetUserByNameAsync(Username) ?? throw new Exception("User not exist");
            return await Task.FromResult(user);
        }
        private bool CheckPassword(User user, string Password)
        {
            return Crypto.VerifyHashedPassword(user.Password, Password);
        }
        private string HashPassword(string password)
        {
            return Crypto.HashPassword(password);
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

            var roles = (await _repositoryManager.Users.GetUserWithDetailAsync(user.Id)).Roles;            
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role,role.Name));
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
