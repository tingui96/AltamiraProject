using Contracts;
using Contracts.Repository;
using Contracts.Services;
using Microsoft.Extensions.Configuration;

namespace Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<IUserServices> _userServices;
        private readonly Lazy<IAuthService> _authService;
        private readonly Lazy<IObraService> _obraService;
        private readonly Lazy<IRoleService> _roleService;
        private readonly Lazy<IImageService> _imageService;
        public ServiceManager(IRepositoryManager repositoryManager, IConfiguration configuration,ILoggerManager loggerManager)
        {
            _authService = new Lazy<IAuthService>(() => new AuthService(repositoryManager, loggerManager, configuration));
            _userServices = new Lazy<IUserServices>(() => new UserService(repositoryManager,loggerManager));
            _obraService = new Lazy<IObraService>(() => new ObraService(repositoryManager, loggerManager));
            _roleService = new Lazy<IRoleService>(() => new RoleService(repositoryManager, loggerManager));
            _imageService = new Lazy<IImageService>(() => new ImageService(repositoryManager, loggerManager));
        }
        public IUserServices UserService => _userServices.Value;
        public IAuthService AuthService => _authService.Value;
        public IObraService ObraService => _obraService.Value;
        public IRoleService RoleService => _roleService.Value;
        public IImageService ImageService => _imageService.Value;
    }
}
