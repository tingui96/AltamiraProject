using Contracts;
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
using System.Text.RegularExpressions;

namespace Services
{
    public class AuthService : IAuthService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly ILoggerManager _loggerManager;
        private readonly IConfiguration _configuration;

        public AuthService(IRepositoryManager repositoryManager,ILoggerManager loggerManager, IConfiguration configuration)
        {
            _repositoryManager = repositoryManager;
            _loggerManager = loggerManager;
            _configuration = configuration;
        }  

        public async Task<AuthResponse> LoginAsync(LoginModel model)
        {
            var userToVerify = await UserExists(model.Usuario);
            var check = VerifyPassword(userToVerify.Password, model.Password);
            if (check)
            {

                var role = userToVerify.Role;
                var claims = GetClaims(userToVerify,role);
                var token = GetToken(claims);
                var user = userToVerify.Adapt<UserResponse>();
                return new AuthResponse(token, user);
            }
            throw new PasswordBadRequestException();
        }
        
        public async Task RegisterAsync(RegisterModel model)
        {
            var user = model.Adapt<User>();
            var findUserName = (await _repositoryManager.Users.GetAllUsersWhere(x => x.UserName.Equals(model.UserName) || x.Email.Equals(model.Email)))
                .FirstOrDefault();
            if(findUserName is not null && findUserName.UserName.ToLower() == model.UserName.ToLower()) throw new UserExistBadRequestException();
            if (findUserName is not null && findUserName.Email == model.UserName) throw new EmailExistBadRequestException();
            if (!VerifyEmail(model.Email)) throw new EmailExpectedBadRequestException();
            IsValidPassword(model.Password);
            if (model.Password != model.ConfirmPassword) throw new PasswordConfirmBadRequestException();
            user.Password = HashPassword(user.Password);
            user.RoleId = (int)RoleEnum.Viewer;
            _repositoryManager.Users.CreateUser(user);
            await _repositoryManager.UnitOfWork.SaveChangesAsync();
        }

        private string HashPassword(string password)
        {
            return Crypto.HashPassword(password);
        }
        // Method to verify the password hash against the given password
        private bool VerifyPassword(string hash, string password)
        {
            return Crypto.VerifyHashedPassword(hash, password);
        }
        private bool VerifyEmail(string email)
        {
            string pattern = @"^[\w\.-]+@([\w-]+\.)+[\w-]{2,4}$";
            return Regex.IsMatch(email, pattern);
        }
        private bool IsValidPassword(string password)
        {
            string pattern = @"[A-Z]";
            if (!Regex.IsMatch(password, pattern)) throw new PasswordUpperBadRequestException();
            pattern = @"\d";
            if (!Regex.IsMatch(password, pattern)) throw new PasswordNumberBadRequestException();
            pattern = @"[a-z]";
            if (!Regex.IsMatch(password, pattern)) throw new PasswordLowerBadRequestException();
            //pattern = @"[!@#$%^&*()_+=|<>?{}\\[\\]~-]";
            //if (!Regex.IsMatch(password, pattern)) throw new PasswordCharacterBadRequestException();
            if (password.Length < 8) throw new PasswordLengthBadRequestException();
            return true;
        }

        private async Task<User> UserExists(string Username)
        {
            var user = await _repositoryManager.Users.GetUserByUserNameAsync(Username) ?? throw new UserNotFoundException();
            if (!user.Activo)
            {
                _loggerManager.LogInfo($"User inactive with id:{user.Id}");
                throw new UserNotFoundException();
            } 
            return await Task.FromResult(user);
        }
        private List<Claim> GetClaims(User user,Role role)
        {
            var issuer = _configuration.GetSection("Jwt")["Issuer"];
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, user.Email, ClaimValueTypes.Email, issuer),
                new Claim(ClaimTypes.AuthenticationMethod, "bearer", ClaimValueTypes.String, issuer),
                new Claim(ClaimTypes.UserData, user.Id.ToString(), ClaimValueTypes.String, issuer),
                new Claim(ClaimTypes.Role,role.Name,ClaimValueTypes.String, issuer)
            };
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
