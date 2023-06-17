using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ErrorController : ControllerBase
    {
        [HttpPost]
        [Route("/error")]
        public IActionResult Error()
        {
            //Exception? exception = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;

            //var (statusCode, message) = exception switch
            //{
            //    IServiceException serviceException => (serviceException.StatusCode,serviceException.ErrorMessage),
            //    _ => (StatusCodes.Status500InternalServerError, "An unexpected error occurred")
            //};


            //return Problem(null,null,statusCode, message);
            return null;
        }   
    }
}
