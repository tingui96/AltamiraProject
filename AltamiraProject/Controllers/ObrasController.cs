using Contracts;
using Contracts.Repository;
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
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        public ObrasController(IRepositoryManager repositoryManager, ILoggerManager logger)
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
