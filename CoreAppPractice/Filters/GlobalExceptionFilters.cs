
using CoreAppPractice.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CoreAppPractice
{
    public class GlobalExceptionFilters : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            var statusCode = context.Exception switch
            {
                NotFoundException => StatusCodes.NotFound,
                BadRequestException => StatusCodes.BadRequest,
                _ => StatusCodes.InternalServer
            };

            context.Result = new ObjectResult(new
            {
                error = context.Exception.Message,
                stackTrace = context.Exception.StackTrace
            })
            {
                StatusCode = statusCode
            };

        }
    }
}
