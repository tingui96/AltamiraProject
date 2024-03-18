using Microsoft.AspNetCore.Http;

namespace Contracts.Repository
{
    public interface IImageRepository
    {
        Task<string> Upload(IFormFile file);
        bool Delete(string pathFile);
    }
}
