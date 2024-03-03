using Entities.Models;
using Microsoft.AspNetCore.Identity;

namespace Contracts.Repository
{
    public interface IRepositoryManager
    {
        IObraRepository Obras { get; }
        IUserRepository Users { get; }
        IRoleRepository Roles { get; }
        IUnitOfWork UnitOfWork { get; }

    }
}
