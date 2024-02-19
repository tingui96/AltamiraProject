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
        private readonly IRepositoryService _repositoryManager;
        private readonly IMapper _mapper;
        public UserController(IRepositoryService repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllUser()
        {
            var users = await _repositoryManager.Users.GetAllUserAsync();
            var result = _mapper.Map<IEnumerable<UserResponse>>(users);
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(string id)
        {
            var user = await _repositoryManager.Users.GetUserByIdAsync(id);
            var result = _mapper.Map<UserResponse>(user);
            return Ok(result);
        }
        [HttpGet("{id}/roles")]
        public async Task<IActionResult> GetAllRoles(string id)
        {
            var result = await _repositoryManager.Users.GetAllRoles(id);
            return Ok(result);
        }
        [HttpGet("role/{roleName}")]
        public async Task<IActionResult> GetUserInRole(string roleName)
        {
            var users = await _repositoryManager.Users.GetUsersInRole(roleName);
            var result = _mapper.Map<IEnumerable<UserResponse>>(users);
            return Ok(result);
        }
        [HttpPost("update/{userId}")]
        public async Task<IActionResult> UpdateUser(string userId,[FromBody] UserToUpdateDTO user)
        {
            var userToUpdate = _mapper.Map<User>(user);
            var result = await _repositoryManager.Users.UpdateUser(userId, userToUpdate);
            return Ok(result);
        }
    }
}
