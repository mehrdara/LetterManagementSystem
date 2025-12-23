using System.Net;
using System.Text.Json;
using API.Common;
using Domain.Exceptions.BaseExceptions;

namespace API.Common
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;
        private readonly IHostEnvironment _env;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger, IHostEnvironment env)
        {
            _next = next;
            _logger = logger;
            _env = env;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                context.Response.ContentType = "application/json";

                var response = new ErrorResponse
                {
                    StatusCode = (int)HttpStatusCode.InternalServerError,
                    Message = "خطایی در سرور رخ داده است",
                    Details = _env.IsDevelopment() ? ex.StackTrace : null
                };

                // مدیریت خطاهای ولیدیشن
                if (ex is FluentValidation.ValidationException validationEx)
                {
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    response.StatusCode = (int)HttpStatusCode.BadRequest;
                    response.Message = "خطای اعتبار سنجی داده‌ها";
                    response.Errors = validationEx.Errors.Select(x => x.ErrorMessage).ToList();
                }
                else if (ex is KeyNotFoundException)
                {
                    context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                    response.StatusCode = (int)HttpStatusCode.NotFound;
                    response.Message = "منبع مورد نظر یافت نشد";
                }
                if (ex is BadRequestException domainEx)
                {
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    response.StatusCode = (int)HttpStatusCode.BadRequest;
                    response.Message = domainEx.Message;
                }
                else if (ex is Microsoft.EntityFrameworkCore.DbUpdateException dbEx)
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    response.Message = "خطا در ذخیره‌سازی داده‌ در پایگاه داده";
                    var innerMessage = dbEx.InnerException?.Message ?? dbEx.Message;
                    response.Details = _env.IsDevelopment() ? innerMessage : null;
                }

                var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
                var json = JsonSerializer.Serialize(response, options);
                await context.Response.WriteAsync(json);
            }
        }
    }
}
