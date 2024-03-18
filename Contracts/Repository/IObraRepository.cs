using Entities.Models;
using Entities.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Repository
{
    public interface IObraRepository 
    {
        Task<IEnumerable<Obra>> GetAllObrasAsync(bool trackChanges = false);
        Task<IEnumerable<Obra>> GetObrasByArtistAsync(int userId, bool trackChanges = false);
        Task<Obra> GetObraByIdAsync(int obraId, bool trackChanges = false);
        void CreateObra(Obra entity);
        void UpdateObra(Obra entity);
        void DeleteObra(Obra entity);
    }
}
