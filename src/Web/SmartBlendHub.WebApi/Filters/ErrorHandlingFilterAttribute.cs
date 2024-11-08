using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace SmartBlendHub.WebApi.Filters
{
    public class ErrorHandlingFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            var exception = context.Exception;
            var errorResult = new { error = "An error accured while proccessing your request." };
            context.Result = new ObjectResult(errorResult)
            {
                StatusCode = 500
            };
            context.ExceptionHandled = true;
        }
    }
}
