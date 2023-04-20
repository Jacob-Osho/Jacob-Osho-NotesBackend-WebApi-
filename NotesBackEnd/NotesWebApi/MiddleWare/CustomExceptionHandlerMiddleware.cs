using FluentValidation;
using Microsoft.AspNetCore.Http;
using NotesApplication.Common.Exeptions;
using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace NotesWebApi.Middleware
{
    public class CustomExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public CustomExceptionHandlerMiddleware(RequestDelegate next) => _next = next;
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }
        private Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            var code = HttpStatusCode.InternalServerError;
            var result = string.Empty;
            switch (ex)
            {
                case ValidationException validationException:
                    code = HttpStatusCode.BadRequest;
                    result = JsonSerializer.Serialize(validationException.Errors);
                    break;
                case NotFoundExeption:
                    code = HttpStatusCode.NotFound;
                    break;
            }
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = Convert.ToInt32(code);
            if (result == null)
            {
                result = JsonSerializer.Serialize(new
                {
                    error = ex.Message
                });
            }
            return context.Response.WriteAsync(result);
        }

    }
}
