using System.Net;

namespace api_animes.Middleware
{
    public class ErrorMiddleware
    {
        public readonly RequestDelegate _next;

        public ErrorMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception e)
            {
                await HandleExceptionAsync(context, e);
            }

            if(context.Response.StatusCode == (int)HttpStatusCode.BadRequest)
            {
                await HandleBadRequestExceptionAsync(context);
            }else if(context.Response.StatusCode == (int)HttpStatusCode.NotFound)
            {
                await HandleNotFoundExceptionAsync(context);
            }
        }

        private Task HandleNotFoundExceptionAsync(HttpContext context)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.NotFound;

            var response = new
            {
                statusCode = context.Response.StatusCode,
                Message = "Não foi possível encontrar este recurso"
            };

            return context.Response.WriteAsJsonAsync(response);
        }

        private Task HandleBadRequestExceptionAsync(HttpContext context)
        {
            context.Response.ContentType = " application/json";
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;

            var response = new
            {
                statusCode = context.Response.StatusCode,
                Message = "Ocorreu um erro na requiçãdo no lado do Cliente"
            };

            return context.Response.WriteAsJsonAsync(response);
        }

        private Task HandleExceptionAsync(HttpContext context, Exception e)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var response = new
            {
                statusCode = context.Response.StatusCode,
                Message = "Ocorreu um interno do servidor."
            };

            return context.Response.WriteAsJsonAsync(response);
        }
    }
}
