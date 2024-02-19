using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts.Repository;

namespace Contracts.Services
{
    public interface IRepositoryService
    {
        IObraRepository Obras { get; }
        IUserRepository Users { get; }
        IRoleRepository Roles { get; }
        Task SaveAsync();

    }
}
