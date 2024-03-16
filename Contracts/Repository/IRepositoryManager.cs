using Entities.Models;
using Microsoft.AspNetCore.Identity;

namespace Contracts.Repository
{
    public interface IRepositoryManager
    {
        IObraRepository Obras { get; }
        IUserRepository Users { get; }
        IRoleRepository Roles { get; }
        IImageRepository Images { get; }
        IUnitOfWork UnitOfWork { get; }

    }
}
