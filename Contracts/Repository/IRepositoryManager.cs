using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Repository
{
    public interface IRepositoryManager
    {
        IObraRepository Obras { get; }
        IUserRepository Users { get; }
        IRoleRepository Roles { get; }
        Task SaveAsync();

    }
}
