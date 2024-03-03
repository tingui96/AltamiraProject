using Contracts.Repository;
using Entities;
using Entities.Models;
using Microsoft.AspNetCore.Identity;

namespace Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private Lazy<IObraRepository> _obraRepository;
        private Lazy<IUserRepository> _userRepository;
        private Lazy<IRoleRepository> _roleRepository;
        private Lazy<IUnitOfWork> _unitOfWork;
        
        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _obraRepository = new Lazy<IObraRepository>(() => new ObraRepository(repositoryContext));
            _userRepository = new Lazy<IUserRepository>(() => new UserRepository(repositoryContext));
            _roleRepository = new Lazy<IRoleRepository>(() => new RoleRepository(repositoryContext));
            _unitOfWork = new Lazy<IUnitOfWork>(() => new UnitOfWork(repositoryContext));
        }
        public IObraRepository Obras => _obraRepository.Value; 

        public IUserRepository Users => _userRepository.Value;


        public IUnitOfWork UnitOfWork => _unitOfWork.Value;

        public IRoleRepository Roles => _roleRepository.Value;

    }
}
