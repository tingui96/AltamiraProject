using Contracts.Repository;
using Contracts.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<IUserServices> _userServices;
        private readonly Lazy<IAuthService> _authService;
        public ServiceManager(IRepositoryManager repositoryManager)
        {
            _authService = new Lazy<IAuthService>(() => new AuthService(repositoryManager));
            _userServices = new Lazy<IUserServices>(() => new UserService(repositoryManager));
        }
        public IUserServices UserService => _userServices.Value;
        public IAuthService AuthService => _authService.Value;
    }
}
