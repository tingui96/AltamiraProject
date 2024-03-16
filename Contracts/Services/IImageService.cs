using Microsoft.AspNetCore.Http;

namespace Contracts.Services
{
    public interface IImageService
    {
        Task<string> GetImageAsync(string url);
        Task<string> UploadImageAsync(IFormFile file);
    }
}
