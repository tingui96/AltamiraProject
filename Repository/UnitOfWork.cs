using Contracts.Repository;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly RepositoryContext _dbContext;
        public UnitOfWork(RepositoryContext repositoryContext)
        {
            _dbContext = repositoryContext;
        }

        public Task SaveChangesAsync() => _dbContext.SaveChangesAsync();
    }
}
