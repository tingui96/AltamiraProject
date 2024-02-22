using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts.Repository;

namespace Contracts.Services
{
    public interface IServiceManager
    {
        IUserServices UserService { get; }
        IAuthService AuthService { get; }
        IObraService ObraService { get; }

    }
}
