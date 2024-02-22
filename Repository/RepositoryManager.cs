using Contracts.Repository;
using Entities;
using Entities.Models;
using Microsoft.AspNetCore.Identity;

namespace Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private Lazy<IObraRepository> _obraRepository;
        private UserManager<User> _userRepository;
        private Lazy<IUnitOfWork> _unitOfWork;
        
        public RepositoryManager(RepositoryContext repositoryContext,UserManager<User> userManager)
        {
            _obraRepository = new Lazy<IObraRepository>(() => new ObraRepository(repositoryContext));
            _userRepository = userManager;
            _unitOfWork = new Lazy<IUnitOfWork>(() => new UnitOfWork(repositoryContext));
        }
        public IObraRepository Obras => _obraRepository.Value; 

        public UserManager<User> Users => _userRepository;


        public IUnitOfWork UnitOfWork => _unitOfWork.Value;

    }
}
