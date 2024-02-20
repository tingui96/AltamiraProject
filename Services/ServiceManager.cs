using Contracts.Repository;
using Contracts.Services;
using Microsoft.Extensions.Configuration;
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
        private readonly Lazy<IRoleService> _roleRepository;
        private readonly Lazy<IObraService> _obraService;
        public ServiceManager(IRepositoryManager repositoryManager, IConfiguration configuration)
        {
            _authService = new Lazy<IAuthService>(() => new AuthService(repositoryManager, configuration));
            _userServices = new Lazy<IUserServices>(() => new UserService(repositoryManager));
            _roleRepository = new Lazy<IRoleService>(() => new RoleService(repositoryManager));
            _obraService = new Lazy<IObraService>(() => new ObraService(repositoryManager));
        }
        public IUserServices UserService => _userServices.Value;
        public IAuthService AuthService => _authService.Value;
        public IRoleService RoleService => _roleRepository.Value;
        public IObraService ObraService => _obraService.Value;
    }
}
