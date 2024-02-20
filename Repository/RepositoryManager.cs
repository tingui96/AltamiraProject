using Contracts.Repository;
using Entities;

namespace Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private Lazy<IObraRepository> _obraRepository;
        private Lazy<IRoleRepository> _roleRepository;
        private Lazy<IUserRepository> _userRepository;
        private Lazy<IUnitOfWork> _unitOfWork;
        
        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _obraRepository = new Lazy<IObraRepository>(() => new ObraRepository(repositoryContext));
            _userRepository = new Lazy<IUserRepository>(() => new UserRepository(repositoryContext));
            _roleRepository = new Lazy<IRoleRepository>(() => new RoleRepository(repositoryContext));
            _unitOfWork = new Lazy<IUnitOfWork>(() => new )
        }
        public IObraRepository Obras 
        {
            get
            {
                if (_obraRepository == null)
                    _obraRepository = new ObraRepository(_repositoryContext);
                return _obraRepository;
            }
        }
        public IRoleRepository Roles
        { 
            get
            {
                if (_roleRepository == null)
                    _roleRepository = new RoleRepository(_repositoryContext);
                return _roleRepository;
            }
        }
        public IUserRepository Users
        {
            get
            {
                if (_userRepository == null)
                    _userRepository = new UserRepository(_repositoryContext);
                return _userRepository;
            }
        }

        public IUnitOfWork UnitOfWork => _repositoryContext.SaveChangesAsync();

        public async Task SaveAsync()
        {
            await _repositoryContext.SaveChangesAsync(); 
        }
    }
}
