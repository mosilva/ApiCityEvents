using ApiCityEvents.Core.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ApiCityEvents.Filters
{
    public class LogActionFilterCheckExictsCityEventForId : ActionFilterAttribute
    {
        private readonly ICityEventService _cityEventService;
        public LogActionFilterCheckExictsCityEventForId(ICityEventService cityEventService)
        {
            _cityEventService = cityEventService;
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            int id = 0;

            try
            {
                id = (int) context.ActionArguments["index"];
            }
            catch (FormatException e)
            {
                var tipoExcecao = e.GetType().Name;
                var mensagem = e.Message;
                var caminho = e.InnerException?.StackTrace;

                Console.WriteLine($"Exception Type: {tipoExcecao}\n" +
                    $"MESSAGE: {mensagem}\n" +
                    $"STACK TRACE: {caminho}");

                context.Result = new StatusCodeResult(StatusCodes.Status406NotAcceptable);
            }
            catch (OverflowException e)
            {
                var tipoExcecao = e.GetType().Name;
                var mensagem = e.Message;
                var caminho = e.InnerException?.StackTrace;

                Console.WriteLine($"Exception Type: {tipoExcecao}\n" +
                    $"MESSAGE: {mensagem}\n" +
                    $"STACK TRACE: {caminho}");

                context.Result = new StatusCodeResult(StatusCodes.Status406NotAcceptable);
            }
            catch (Exception e)
            {
                var tipoExcecao = e.GetType().Name;
                var mensagem = e.Message;
                var caminho = e.InnerException?.StackTrace;

                Console.WriteLine($"Exception Type: {tipoExcecao}\n" +
                    $"MESSAGE: {mensagem}\n" +
                    $"STACK TRACE: {caminho}");

                context.Result = new StatusCodeResult(StatusCodes.Status406NotAcceptable);
            }

            if (_cityEventService.CheckExictsCityEvent(id))
            {
                context.Result = new StatusCodeResult(StatusCodes.Status404NotFound);
            }

        }
    }
}
