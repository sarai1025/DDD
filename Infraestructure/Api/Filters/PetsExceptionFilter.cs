using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using PetsFoundation.Domain.Exceptions;

namespace PetsFoundation.Infraestructure.Api.Filters
{
    public class PetsExceptionFilter : IExceptionFilter
    {
        private readonly ILogger<PetsExceptionFilter> logger;
        public PetsExceptionFilter(ILogger<PetsExceptionFilter> logger)
        {
            this.logger = logger;
        }
        public void OnException(ExceptionContext context)
        {
            var statusCode = context.Exception switch
            {
                ValidationException => StatusCodes.Status400BadRequest,
                _ => StatusCodes.Status500InternalServerError
            };

            context.Result = new ObjectResult(new
            {
                error = context.Exception.Message,
                stackTrace = context.Exception.StackTrace
            })
            {
                StatusCode = statusCode
            };

            logger.LogError($"Error: {context.Exception.Message} StackTrace: {context.Exception.StackTrace}");
        }
    }
}
