using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ApiCityEvents.Filters
{
    public class GeneralExceptionFilter : IExceptionFilter
    {

        public void OnException(ExceptionContext context)
        {
            var problem = new ProblemDetails
            {
                Status = 500,
                Title = "Erro Inesperado",
                Detail = "Os eventos estão fora de serviço, por favor, tente mais tarde"
            };

            Console.WriteLine($"EXCEPTION TYPE: {context.GetType().Name}\n" +
            $"MESSAGE: {context.Exception.Message}\n" +
            $"STACK TRACE: {context.Exception.InnerException?.StackTrace}");

            switch (context.Exception)
            {
                case ArgumentNullException:
                    context.HttpContext.Response.StatusCode = StatusCodes.Status501NotImplemented;
                    context.Result = new ObjectResult(problem);
                    break;
                case ArgumentException:
                    context.HttpContext.Response.StatusCode = StatusCodes.Status501NotImplemented;
                    context.Result = new ObjectResult(problem);
                    break;
                default:
                    context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
                    context.Result = new ObjectResult(problem);
                    break;
            }
        }
    }
}
