using Contracts.Repository;
using Entities;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private IObraRepository _obraRepository;
        private IRoleRepository _roleRepository;
        private IUserRepository _userRepository;
        private RepositoryContext _repositoryContext;
        public RepositoryManager(RepositoryContext repositoryContext)
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
