using Entities.Models;
using Microsoft.AspNetCore.Identity;

namespace Contracts.Repository
{
    public interface IRepositoryManager
    {
        IObraRepository Obras { get; }
        UserManager<User> Users { get; }
        IUnitOfWork UnitOfWork { get; }

    }
}
