using Contracts;
using Contracts.Repository;
using Entities.Enum;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AltamiraProject.Validation
{
    public class ObraAuthorizationFilter : IAsyncActionFilter
    {
        private readonly IConfiguration _configuration;
        private readonly ILoggerManager _logger;
        private readonly IRepositoryManager _repositoryManager;
        public ObraAuthorizationFilter(IRepositoryManager repositoryManager, ILoggerManager loggerManager, IConfiguration configuration)
        {
            _configuration = configuration; 
            _logger = loggerManager;
            _repositoryManager = repositoryManager;
        }
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var token = context.HttpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            if (token == null)
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            try
            {
                // Valida el token
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                var handler = new JwtSecurityTokenHandler();
                var claimsPrincipal = handler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidIssuer = _configuration["Jwt:Issuer"],
                    ValidAudience = _configuration["Jwt:Audience"],
                    IssuerSigningKey = key
                }, out var validatedToken);

                // Obtiene el ID de usuario del token
                var userIdClaim = claimsPrincipal.Claims.FirstOrDefault(c => c.Type == ClaimTypes.UserData);
                if (userIdClaim == null || !int.TryParse(userIdClaim.Value, out var userId))
                {
                    _logger.LogInfo($"UserIdClaim for token is Null or Cant parse");
                    context.Result = new UnauthorizedResult();
                    return;
                }
                // Obtiene el rol del usuario del token
                var roleClaim = claimsPrincipal.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role);
                if (roleClaim == null)
                {
                    _logger.LogInfo($"roleClaim for token is Null");
                    context.Result = new UnauthorizedResult();
                    return;
                }
                // Obtiene el ID de obra del parámetro de ruta
                if (context.ActionArguments.TryGetValue("id", out var routeIdObj) && routeIdObj is int routeId)
                {
                    _logger.LogError($"User id {userId} with role: {roleClaim.Value} cant modify the Obra {routeId} because is not Authorized");
                    // Verifica si el ID de usuario en el token coincide con el de la ruta
                    var obra = await _repositoryManager.Obras.GetObraByIdAsync(routeId);
                    if (userId != obra.UserId && roleClaim.Value != RoleEnum.Administrador.ToString())
                    {
                        context.Result = new UnauthorizedResult();
                        return;
                    }
                }
                else
                {
                    context.Result = new BadRequestResult();
                    return;
                }
                // Continúa con el siguiente filtro
                await next();
            }
            catch (Exception)
            {
                context.Result = new UnauthorizedResult();
            }
        }
    }
}
