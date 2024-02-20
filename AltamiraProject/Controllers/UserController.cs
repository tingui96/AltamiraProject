using AutoMapper;
using Contracts.Services;
using Entities.DTO.Request;
using Entities.DTO.Response;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository;

namespace AltamiraProject.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IServiceManager _repositoryService;
        public UserController(IServiceManager repositoryService, IMapper mapper)
        {
            _repositoryService = repositoryService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllUser()
        {
            var users = await _repositoryService.Users.GetAllUserAsync();
            var result = _mapper.Map<IEnumerable<UserResponse>>(users);
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(Guid id)
        {
            var user = await _repositoryService.Users.GetUserByIdAsync(id);
            var result = _mapper.Map<UserResponse>(user);
            return Ok(result);
        }
        [HttpGet("{id}/roles")]
        public async Task<IActionResult> GetAllRoles(Guid id)
        {
            var result = await _repositoryService.Users.GetUserWithDetailAsync(id);
            return Ok(result);
        }
        [HttpGet("role/{roleId}")]
        public async Task<IActionResult> GetUserInRole(Guid roleId)
        {
            var users = await _repositoryService.Roles.GetRoleWithDetailAsync(roleId);
            var result = _mapper.Map<IEnumerable<UserResponse>>(users);
            return Ok(result);
        }
        [HttpPost("update/{userId}")]
        public async Task<IActionResult> UpdateUser(string userId,[FromBody] UserToUpdateDTO user)
        {
            return Ok();
        }
    }
}
