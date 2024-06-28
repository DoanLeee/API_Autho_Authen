using Microsoft.AspNetCore.Diagnostics;
using System.Reflection.Metadata.Ecma335;

namespace Exception_Handling_Middleware
{
    public class AppNotImplementExceptionHandler : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {

            if(exception is NotImplementedException)
            {
                var response = new ErrorResponse()
                {
                    StatusCode = StatusCodes.Status501NotImplemented,
                    ExceptionMessage = exception.Message,
                    Title = "Something went wrong"
                };
                await httpContext.Response.WriteAsJsonAsync(response, cancellationToken);
                httpContext.Response.StatusCode = StatusCodes.Status501NotImplemented;
                return true;
            }
            return false;
            
        }
    }
}
