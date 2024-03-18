using AltamiraProject.ApiResponse;
using AltamiraProject.Validation;
using Contracts;
using Contracts.Services;
using Entities.DTO.Request;
using Entities.RequestFeatures;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AltamiraProject.Controllers
{
    [Route("api/obras")]
    [ApiController]
    public class ObrasController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;
        private readonly ILoggerManager _logger;
        public ObrasController(IServiceManager serviceManager, ILoggerManager logger)
        {
            _serviceManager = serviceManager;
            _logger = logger;
        }
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetAllObras([FromQuery] ObraParameters obraParameters) 
        {
            var obras = await _serviceManager.ObraService.GetAllObrasAsync(obraParameters);
            Response.Headers.Append("X-Pagination",JsonConvert.SerializeObject(obras.MetaData));
            return Ok(new ApiOkResponse(obras));
        }
        
        [HttpGet("{id}",Name = "GetObraById")]
        public async Task<IActionResult> GetObraById(int id)
        {
            var obra = await _serviceManager.ObraService.GetObrabyIdAsync(id);
            return Ok(new ApiOkResponse(obra));
        }
        [HttpPost]
        [Authorize(Roles = "Administrador,Artist")]
        public async Task<IActionResult> CreateObra(ObraModel obraModel)
        {
            var obra = await _serviceManager.ObraService.CreateObraAsync(obraModel);
            return CreatedAtRoute("GetObraById", new { obra.Id }, obra);
        }
        [HttpPut("{id}")]
        [Authorize(Roles = "Administrador,Artist")]
        [ServiceFilter(typeof(ObraAuthorizationFilter))]
        public async Task<IActionResult> UpdateObra(int id, ObraToUpdateDTO obraToUpdate)
        {
            var result = await _serviceManager.ObraService.UpdateObraAsync(id, obraToUpdate);
            return Ok(new ApiOkResponse(result));
        }
        [HttpDelete("{id}")]
        [Authorize(Roles = "Administrador,Artist")]
        [ServiceFilter(typeof(ObraAuthorizationFilter))]
        public async Task<IActionResult> DeleteObra(int id)
        {
            await _serviceManager.ObraService.DeleteObraAsync(id);
            return Ok(new ApiOkResponse());
        }
    }
}
