using Domain.Exceptions;
using ErrorModels;

namespace Order_Management_System.Custom_MiddleWares
{
    public class CustomExceptionHandlerMiddleWare
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<CustomExceptionHandlerMiddleWare> _logger;

        public CustomExceptionHandlerMiddleWare(RequestDelegate next,ILogger<CustomExceptionHandlerMiddleWare> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
                if(context.Response.StatusCode == StatusCodes.Status404NotFound)
                {
                    var Response = new ErrorToReturn
                    {
                        StatusCode = context.Response.StatusCode,
                        Message = $"{context.Request.Path} not found"
                    };
                    await context.Response.WriteAsJsonAsync(Response);
                }
            }
            catch(Exception ex)
            {
               _logger.LogError(ex, "An error occured");
                context.Response.StatusCode = ex switch
                {
                    NotFoundException => StatusCodes.Status404NotFound,
                    _ => StatusCodes.Status500InternalServerError
                };
                var Response = new ErrorToReturn
                {
                    StatusCode = context.Response.StatusCode,
                    Message = "An error occured",
                };
                await context.Response.WriteAsJsonAsync(Response);
            }
           
        }
    }
}
