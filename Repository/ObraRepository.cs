using Contracts.Repository;
using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ObraRepository : RepositoryBase<Obra>, IObraRepository
    {
        public ObraRepository(RepositoryContext repositoryContext) : base(repositoryContext) { }

        public void CreateObra(Obra entity)
        {
            Create(entity);
        }
        public void DeleteObra(Obra entity)
        {
            Delete(entity);
        }
        public async Task<IEnumerable<Obra>> GetAllObrasAsync(bool trackChanges)
        {
            return await FindAll(trackChanges)
            .OrderBy(O => O.Titulo)
            .ToListAsync();
        }
        public async Task<Obra> GetObraByIdAsync(Guid obraId,bool trackChanges)
        {
            return await FindByCondition(obra =>
                obra.Id.Equals(obraId), trackChanges)
                .FirstOrDefaultAsync();
        }
        public void UpdateObra(Obra entity)
        {
            Update(entity);
        }
      
    }
}
