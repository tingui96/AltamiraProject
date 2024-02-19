using AutoMapper;
using Contracts.Repository;
using Contracts.Services;
using CryptoHelper;
using Entities.DTO;
using Entities.Models;

namespace Services
{
    public class AuthService : IAuthService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public AuthService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }  

        public async Task<User> Login(LoginModel model)
        {
            var userToVerify = await UserExists(model.Usuario);
            var check = CheckPassword(userToVerify, model.Password);
            if (check) return await Task.FromResult(userToVerify);
            throw new Exception("Wrong Password");
        }

        public async Task<User> Register(RegisterModel model)
        {
            var user = _mapper.Map<User>(model);
            user.Password = HashPassword(model.Password);
            _repositoryManager.Users.CreateUser(user); 
            return await Task.FromResult(user);
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
    }       
}
