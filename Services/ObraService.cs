using Contracts.Repository;
using Contracts.Services;
using Entities.DTO.Request;
using Entities.DTO.Response;
using Entities.Models;
using Mapster;

namespace Services
{
    public class ObraService : IObraService
    {
        private readonly IRepositoryManager _repositoryManager;
        public ObraService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task<ObraResponse> CreateObraAsync(ObraModel model)
        {
            var obra = model.Adapt<Obra>();
            _repositoryManager.Obras.CreateObra(obra);
            await _repositoryManager.UnitOfWork.SaveChangesAsync();
            var result = obra.Adapt<ObraResponse>();
            return await Task.FromResult(result);
        }

        public async Task DeleteObraAsync(Guid obraId)
        {
            var obra = await _repositoryManager.Obras.GetObraByIdAsync(obraId);
            _repositoryManager.Obras.DeleteObra(obra);
            await _repositoryManager.UnitOfWork.SaveChangesAsync();
        }

        public async Task<IEnumerable<ObraResponse>> GetAllObrasAsync()
        {
            var obras = await _repositoryManager.Obras.GetAllObrasAsync();
            var result = obras.Adapt<IEnumerable<ObraResponse>>();
            return await Task.FromResult(result);
        }

        public async Task<ObraResponse> GetObrabyIdAsync(Guid obraId)
        {
            var obra = await _repositoryManager.Obras.GetObraByIdAsync(obraId);
            var result = obra.Adapt<ObraResponse>();
            return await Task.FromResult(result);
        }

        public async Task UpdateObraAsync(Guid obraId, ObraToUpdateDTO model)
        {
            var obra = await _repositoryManager.Obras.GetObraByIdAsync(obraId);
            var result = model.Adapt(obra);
            _repositoryManager.Obras.UpdateObra(result);
            await _repositoryManager.UnitOfWork.SaveChangesAsync();
        }
    }
}
