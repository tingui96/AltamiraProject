using AltamiraProject.ApiResponse;
using Contracts.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AltamiraProject.Controllers
{
    [Route("api/roles")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;
        public RoleController(IServiceManager repositoryService)
        {
            _serviceManager = repositoryService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllRole()
        {
            var roles = await _serviceManager.RoleService.GetAllRoleAsync();
            return Ok(new ApiOkResponse(roles));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRoleById(int id)
        {
            var role = await _serviceManager.RoleService.GetRoleByIdAsync(id);
            return Ok(new ApiOkResponse(role));
        }
        [HttpGet("name/{name}")]
        public async Task<IActionResult> GetRoleById(string name)
        {
            var role = await _serviceManager.RoleService.GetRoleByNameAsync(name);
            return Ok(new ApiOkResponse(role));
        }
    }
}
