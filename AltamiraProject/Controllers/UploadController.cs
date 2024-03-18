using AltamiraProject.ApiResponse;
using Contracts.Services;
using Microsoft.AspNetCore.Mvc;

namespace AltamiraProject.Controllers
{
    [Route("api/upload")]
    [ApiController]
    public class UploadController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;
        public UploadController(IServiceManager repositoryService)
        {
            _serviceManager = repositoryService;
        }
        [HttpPost, DisableRequestSizeLimit]
        public async Task<IActionResult> Upload()
        {
            var formCollection = await Request.ReadFormAsync();
            var file = formCollection.Files.First();
            var result = _serviceManager.ImageService.UploadImageAsync(file);
            return Ok(new ApiOkResponse(result));
        }
    }
}
