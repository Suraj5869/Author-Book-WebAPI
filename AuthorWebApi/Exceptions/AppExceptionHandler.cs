using AuthorWebApi.Models;
using Microsoft.AspNetCore.Diagnostics;

namespace AuthorWebApi.Exceptions
{
    public class AppExceptionHandler : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            var response = new ErrorResponse();
            if((exception is AuthorNotFoundException) || (exception is BookNotFoundException) || (exception is AuthorDetailsNotFoundException))
            {
                response.StatusCode = StatusCodes.Status404NotFound;
                response.Title = "Wrong Input";
                response.ExceptionMessage = exception.Message;
            }
            else
            {
                response.StatusCode = StatusCodes.Status500InternalServerError;
                response.Title = "Something went wrong!";
                response.ExceptionMessage += exception.Message;
            }

            await httpContext.Response.WriteAsJsonAsync(response, cancellationToken);
            return true;
        }
    }
}
