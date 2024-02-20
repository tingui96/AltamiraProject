using Entities.DTO.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Services
{
    public interface IObraService
    {
        Task<IEnumerable<ObraResponse>> GetAllObrasAsync();
    }
}
