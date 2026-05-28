using Microsoft.AspNetCore.Diagnostics;

namespace InternProject.API.Middleware
{
    public class GlobalExceptionHandler:IExceptionHandler
    {
        private readonly IProblemDetailsService _problemDetailsService;
        public GlobalExceptionHandler(IProblemDetailsService problemDetailsService)
        {
            _problemDetailsService = problemDetailsService;
            
        }
       public async  ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {

            return true;
        }
    }
}
