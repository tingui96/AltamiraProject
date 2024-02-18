using Contracts.Repository;
using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(RepositoryContext repositoryContext) : base(repositoryContext) { }

        public void CreateUser(User entity)
        {
            Create(entity);
        }

        public void DeleteUser(User entity)
        {
            Delete(entity);
        }

        public async Task<IEnumerable<User>> GetAllUserAsync(bool trackChanges)
        {
            return await FindAll(trackChanges)
                .OrderBy(x => x.UserName)
                .ToListAsync();
        }

        public async Task<User> GetUserByIdAsync(Guid UserId, bool trackChanges)
        {
            return await FindByCondition(x => x.Id.Equals(UserId), trackChanges)
                .FirstOrDefaultAsync();
        }

        public void UpdateUser(User entity)
        {
            Update(entity);
        }
    }
}
