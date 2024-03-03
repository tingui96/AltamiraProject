using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Repository
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllUsersAsync(bool trackChanges = false);
        IQueryable<User> GetAllUsers(Expression<Func<User, bool>> expresion, bool trackChanges = false);
        Task<User> GetUserByIdAsync(int userId, bool trackChanges = false);
        Task<User> GetUserByUserNameAsync(string userName, bool trackChanges = false);
        void CreateUser(User entity);
        void UpdateUser(User entity);
        void DeleteUser(User entity);
    }
}
