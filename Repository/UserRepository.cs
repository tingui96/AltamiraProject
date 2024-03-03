using Contracts.Repository;
using Entities;
using Entities.Exceptions.NotFound;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class UserRepository : RepositoryBase<User> , IUserRepository
    {
        public UserRepository(RepositoryContext repositoryContext):base(repositoryContext)
        {
            
        }

        public void CreateUser(User entity)
        {
            Create(entity);
        }

        public void DeleteUser(User entity)
        {
            Delete(entity);
        }

        public IQueryable<User> GetAllUsers(Expression<Func<User,bool>> expresion, bool trackChanges = false)
        {
            return FindByCondition(expresion, trackChanges);
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync(bool trackChanges = false)
        {
            return await FindAll(trackChanges)
                .Include(x => x.Role)
                .OrderBy(O => O.Name)
                .ToListAsync();
        }

        public async Task<User> GetUserByIdAsync(int userId, bool trackChanges = false)
        {
            var user = await FindByCondition(user =>
                user.Id.Equals(userId), trackChanges)
                .Include(x => x.Role)
                .FirstOrDefaultAsync() ?? throw new UserNotFoundException();
            return await Task.FromResult(user);
        }

        public async Task<User> GetUserByUserNameAsync(string userName, bool trackChanges = false)
        {
            var user = await FindByCondition(user =>
                user.UserName.Equals(userName), trackChanges)
                .Include(x => x.Role)
                .FirstOrDefaultAsync() ?? throw new UserNotFoundException();
            return await Task.FromResult(user);
        }

        public void UpdateUser(User entity)
        {
            Update(entity);
        }
    }
}
