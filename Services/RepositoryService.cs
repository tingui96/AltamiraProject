using Contracts.Repository;
using Contracts.Services;
using Entities;
using Repository;

namespace Services
{
    public class RepositoryService : IRepositoryService
    {
        private IObraRepository _obraRepository {get;set;}
        private IRoleRepository _roleRepository { get;set;}
        private IUserRepository _userRepository { get;set;}
        private RepositoryContext _repositoryContext;
        public RepositoryService(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
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
       
        public async Task SaveAsync()
        {
            await _repositoryContext.SaveChangesAsync(); 
        }
    }
}
