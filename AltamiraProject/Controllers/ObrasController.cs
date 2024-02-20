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
        private readonly IServiceManager _repository;
        private readonly ILoggerManager _logger;
        public ObrasController(IServiceManager repositoryManager, ILoggerManager logger)
        {
            _repository = repositoryManager;
            _logger = logger;
        }
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetObras() 
        {
            var obras = await _repository.Obras.GetAllObrasAsync(trackChanges: false);
            return Ok(obras);
        }
    }
}
