using System;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Net;

namespace sitesweep.Middleware
{
    public class GlobalExceptionMiddleware : Controller
    {
        private readonly RequestDelegate _requestDelegate;
        private readonly ILogger<GlobalExceptionMiddleware> _logger;
        public GlobalExceptionMiddleware(RequestDelegate requestDelegate, ILogger<GlobalExceptionMiddleware> logger)
        {
            _requestDelegate = requestDelegate;
            _logger = logger;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _requestDelegate(httpContext);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Global Exception Caught Error");
            }
        }

        private Task HandleExceptionAsync(HttpContext httpContext, Exception exception)
        {
            string message = "Global caught message";
            HttpStatusCode status = HttpStatusCode.InternalServerError;
            switch (exception)
            {
                case null:
                    status = HttpStatusCode.BadRequest;
                    message = "A new bad request message";
                    break;
            }

            httpContext.Response.StatusCode = (int)status;
            return httpContext.Response.WriteAsync(message);
                
        }
    }
}