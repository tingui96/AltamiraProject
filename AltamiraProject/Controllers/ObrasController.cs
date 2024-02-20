using Contracts;
using Contracts.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

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
        public async Task<IActionResult> GetAllObras() 
        {
            var obras = await _serviceManager.ObraService.GetAllObrasAsync();
            return Ok(obras);
        }
    }
}
