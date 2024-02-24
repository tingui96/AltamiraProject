using Contracts.Repository;
using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class ObraRepository : RepositoryBase<Obra>, IObraRepository
    {
        public ObraRepository(RepositoryContext repositoryContext) : base(repositoryContext) { }

        public void CreateObra(Obra entity)
        {
            Create(entity);
        }
        public void UpdateObra(Obra entity)
        {
            Update(entity);
        }
        public void DeleteObra(Obra entity)
        {
            Delete(entity);
        }
        public async Task<IEnumerable<Obra>> GetAllObrasAsync(bool trackChanges)
        {
            return await FindAll(trackChanges)
                .Include(x => x.User)
                .OrderBy(O => O.Titulo)
                .ToListAsync();
        }
        public async Task<Obra> GetObraByIdAsync(Guid obraId,bool trackChanges)
        {
            var obra = await FindByCondition(obra =>
                obra.Id.Equals(obraId), trackChanges)
                .FirstOrDefaultAsync() ?? throw new Exception("Obra not found");
            return await Task.FromResult(obra);
        }
       
      
    }
}
