using AltamiraProject.CustomExceptionMiddleware;
using Contracts;

namespace AltamiraProject.Extensions
{
    public static class ExceptionMiddlewareExtensions
    {
        public static void ConfigureExceptionHandler(this WebApplication app)
        {
            app.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
