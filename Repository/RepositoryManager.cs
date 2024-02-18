using Contracts.Repository;
using Entities;
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
        public async Task SaveAsync()
        {
            await _repositoryContext.SaveChangesAsync();
            
        }
    }
}
