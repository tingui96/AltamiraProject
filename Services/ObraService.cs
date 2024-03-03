using Contracts.Repository;
using Contracts.Services;
using Entities.DTO.Request;
using Entities.DTO.Response;
using Entities.Exceptions.NotFound;
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

        public async Task DeleteObraAsync(int obraId)
        {
            var obra = await _repositoryManager.Obras.GetObraByIdAsync(obraId) ?? throw new ObraNotFoundException();
            _repositoryManager.Obras.DeleteObra(obra);
            await _repositoryManager.UnitOfWork.SaveChangesAsync();
        }

        public async Task<IEnumerable<ObraResponse>> GetAllObrasAsync()
        {
            var obras = await _repositoryManager.Obras.GetAllObrasAsync();
            var result = obras.Adapt<IEnumerable<ObraResponse>>();
            return await Task.FromResult(result);
        }

        public async Task<ObraResponse> GetObrabyIdAsync(int obraId)
        {
            var obra = await _repositoryManager.Obras.GetObraByIdAsync(obraId) ?? throw new ObraNotFoundException();
            var result = obra.Adapt<ObraResponse>();
            return await Task.FromResult(result);
        }

        public async Task<ObraResponse> UpdateObraAsync(int obraId, ObraToUpdateDTO model)
        {
            var obra = await _repositoryManager.Obras.GetObraByIdAsync(obraId) ?? throw new ObraNotFoundException();
            var entity = model.Adapt(obra);
            _repositoryManager.Obras.UpdateObra(entity);
            await _repositoryManager.UnitOfWork.SaveChangesAsync();
            var result = entity.Adapt<ObraResponse>();
            return await Task.FromResult(result);

        }
    }
}
