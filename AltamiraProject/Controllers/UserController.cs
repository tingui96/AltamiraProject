using Contracts.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository;

namespace AltamiraProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IRepositoryManager _repositoryManager;
        public UserController(IRepositoryManager repositoryManager) 
        {
            _repositoryManager = repositoryManager;
        }
    }
}
