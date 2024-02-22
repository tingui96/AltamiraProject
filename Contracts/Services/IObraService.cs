using Entities.DTO.Request;
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
        Task<ObraResponse> GetObrabyIdAsync(Guid obraId);
        Task<ObraResponse> CreateObraAsync(ObraModel obra);
        Task UpdateObraAsync(Guid obraId,ObraToUpdateDTO obra);
        Task DeleteObraAsync(Guid obraId);
    }
}
