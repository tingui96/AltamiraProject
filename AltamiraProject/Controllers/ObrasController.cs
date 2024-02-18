using Contracts;
using Contracts.Repository;
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
        [HttpGet]
        public IActionResult GetObras() 
        {
            try
            {
                var obras = _repository.Obras.GetAllObrasAsync(trackChanges: false);
                return Ok(obras);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in the {nameof(GetObras)} action { ex } ");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
