﻿using AltamiraProject.ApiResponse;
using Contracts;
using Contracts.Services;
using Entities.DTO.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
            return Ok(new ApiOkResponse(obras));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetObraById(Guid id)
        {
            var obra = await _serviceManager.ObraService.GetObrabyIdAsync(id);
            return Ok(new ApiOkResponse(obra));
        }
        [HttpPost]
        [Authorize(Roles = "Artist")]
        public async Task<IActionResult> CreateObra(ObraModel obraModel)
        {
            var obra = await _serviceManager.ObraService.CreateObraAsync(obraModel);
            return Ok(new ApiOkResponse(obra));
        }
        [HttpPut("{id}")]
        [Authorize(Roles = "Artist")]
        public async Task<IActionResult> UpdateObra(Guid id, ObraToUpdateDTO obraToUpdate)
        {
            await _serviceManager.ObraService.UpdateObraAsync(id, obraToUpdate);
            return Ok(new ApiOkResponse());
        }
        [HttpDelete("{id}")]
        [Authorize(Roles = "Artist")]
        public async Task<IActionResult> DeleteObra(Guid id)
        {
            await _serviceManager.ObraService.DeleteObraAsync(id);
            return Ok(new ApiOkResponse());
        }
    }
}
