using Contracts.Repository;
using Contracts.Services;
using CryptoHelper;
using Entities.DTO;
using Entities.DTO.Response;
using Entities.Enum;
using Entities.Exceptions.BadRequest;
using Entities.Exceptions.NotFound;
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
            if (!userToVerify.Activo) throw new UserNotFoundException();
            var check = await _repositoryManager.Users.CheckPasswordAsync(userToVerify, model.Password);
            if (check)
            {
                var roles = await _repositoryManager.Users.GetRolesAsync(userToVerify);
                var role = roles.Count > 0 ? roles.First() : throw new UserNotFoundException();
                var claims = GetClaims(userToVerify,roles);
                var token = GetToken(claims);
                var user = userToVerify.Adapt<UserResponse>();
                return new AuthResponse(token, user, role);
            }
            throw new PasswordBadRequestException();
        }

        public async Task<UserResponse> RegisterAsync(RegisterModel model)
        {
            var user = model.Adapt<User>();
            var identityResult = await _repositoryManager.Users.CreateAsync(user,model.Password);
            if(identityResult.Errors.Any())
                throw new RegisterBadRequestException(identityResult.Errors); 
            var result = user.Adapt<UserResponse>();
            return await Task.FromResult(result);
        }

        private async Task<User> UserExists(string Username)
        {
            var user = await _repositoryManager.Users.FindByNameAsync(Username) ?? throw new UserNotFoundException();
            if(!user.Activo) throw new UserNotFoundException();
            return await Task.FromResult(user);
        }
        private List<Claim> GetClaims(User user,IList<string> roles)
        {
            var issuer = _configuration.GetSection("Jwt")["Issuer"];
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, user.Email, ClaimValueTypes.Email, issuer),
                new Claim(ClaimTypes.AuthenticationMethod, "bearer", ClaimValueTypes.String, issuer),
                new Claim(ClaimTypes.UserData, user.Id.ToString(), ClaimValueTypes.String, issuer),
            };           
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
