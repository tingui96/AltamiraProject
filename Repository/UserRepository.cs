using Contracts.Repository;
using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(RepositoryContext repositoryContext) : base(repositoryContext) { }

        public void CreateUser(User entity)
        {
            Create(entity);
        }

        public void UpdateUser(User entity)
        {
            Update(entity);
        }
        public void DeleteUser(User entity)
        {
            Delete(entity);
        }
        
        public async Task<IEnumerable<User>> GetAllUserAsync(bool trackChanges)
        {
            return await FindAll(trackChanges)
            .OrderBy(O => O.Name)
            .ToListAsync();
        }
        
        public async Task<User> GetUserByIdAsync(Guid userId, bool trackChanges)
        {
            var user = await FindByCondition(user =>
               user.Id.Equals(userId), trackChanges)
               .FirstOrDefaultAsync() ?? throw new Exception("User not found");
            return await Task.FromResult(user);
        }

        public async Task<User> GetUserByUserNameAsync(string name, bool trackChanges)
        {
            var user = await FindByCondition(user =>
              user.UserName.Equals(name), trackChanges)
              .FirstOrDefaultAsync() ?? throw new Exception("User not found");
            return await Task.FromResult(user);
        }

        public async Task<User> GetUserWithDetailAsync(Guid userId, bool trackChanges)
        {
            var user = await FindByCondition(x => x.Id.Equals(userId), trackChanges)
                .Include(x => x.Roles)
                .FirstOrDefaultAsync()
                ?? throw new Exception("User not found");
            return await Task.FromResult(user);
        }
    }
}
