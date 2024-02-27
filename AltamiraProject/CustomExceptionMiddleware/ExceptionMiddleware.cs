using AltamiraProject.ApiResponse;
using Contracts;
using Entities.ErrorModel;
using Entities.Exceptions;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using System.Net;

namespace AltamiraProject.CustomExceptionMiddleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILoggerManager _logger;
        private string Message { get; set; }
        private int CustomStatusCode { get; set; }

        public ExceptionMiddleware(RequestDelegate next, ILoggerManager logger)
        {
            _logger = logger;
            _next = next;
            Message = "";
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            Message = "";
            CustomStatusCode = 0;
            try
            {
                await _next(httpContext);
            }
            catch (AccessViolationException avEx)
            {
                _logger.LogError($"A new violation exception has been thrown: {avEx}");
                await HandleExceptionAsync(httpContext, avEx);
            }
            catch (BaseException ex)
            {
                Message = ex.CustomMessage ?? ex.Message;
                CustomStatusCode = ex.CustomCode;
                httpContext.Response.StatusCode = ex.HttpCode;
                httpContext.Response.ContentType = "application/json";

                var response = new BasicResponse(httpContext.Response.StatusCode, Message , CustomStatusCode);
                var json = JsonConvert.SerializeObject(response, new JsonSerializerSettings
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                });
                await httpContext.Response.WriteAsync(json);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: {ex}");
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            var message = exception switch
            {
                AccessViolationException => "Access violation error from the custom middleware",
                _ => exception.Message,
            };
            await context.Response.WriteAsync(new ErrorDetails()
            {
                StatusCode = context.Response.StatusCode,
                Message = message
            }.ToString());
        }
    }
}