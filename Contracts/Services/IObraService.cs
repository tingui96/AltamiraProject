using Entities.DTO.Request;
using Entities.DTO.Response;
using Entities.Models;
using Entities.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Services
{
    public interface IObraService
    {
        Task<PagedList<ObraResponse>> GetAllObrasAsync(ObraParameters obraParameters);
        Task<PagedList<ObraResponse>> GetObrasByArtistAsync(int userId, ObraParameters obraParameters);
        Task<ObraResponse> GetObrabyIdAsync(int obraId);
        Task<ObraResponse> CreateObraAsync(ObraModel obra);
        Task<ObraResponse> UpdateObraAsync(int obraId,ObraToUpdateDTO obra);
        Task DeleteObraAsync(int obraId);
    }
}
