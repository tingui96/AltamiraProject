using Contracts.Repository;
using Contracts.Services;
using Entities.DTO.Response;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ObraService : IObraService
    {
        private readonly IRepositoryManager _repositoryManager;
        public ObraService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task<IEnumerable<ObraResponse>> GetAllObrasAsync()
        {
            var obras = await _repositoryManager.Obras.GetAllObrasAsync();
            var result = obras.Adapt<IEnumerable<ObraResponse>>();
            return await Task.FromResult(result);
        }
    }
}
