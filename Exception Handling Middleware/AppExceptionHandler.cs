using Microsoft.AspNetCore.Diagnostics;
using System.Reflection.Metadata.Ecma335;

namespace Exception_Handling_Middleware
{
    public class AppExceptionHandle (ILogger<AppExceptionHandle> logger): IExceptionHandler 
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {

        if (exception is NotImplementedException)
        {
            logger.LogError(exception, exception.Message);
            var response = new ErrorResponse()
            {
                StatusCode = StatusCodes.Status500InternalServerError,
                ExceptionMessage = exception.Message,
                Title = "Something went wrong"
            };
            await httpContext.Response.WriteAsJsonAsync(response, cancellationToken);
            httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
            return true;
        }
        return false;

    }
    
}
}
