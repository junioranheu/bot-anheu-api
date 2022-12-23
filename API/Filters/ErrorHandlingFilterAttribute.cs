using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace API.Filters
{
    public class ErrorHandlingFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            var excecao = context.Exception;

            var detalhes = new ProblemDetails
            {
                Title = "Ocorreu um erro ao processar sua requisição",
                Detail = excecao.Message,
                Status = (int)HttpStatusCode.InternalServerError,
                Instance = context.HttpContext.Request.Path
            };

            context.Result = new ObjectResult(detalhes);

            context.ExceptionHandled = true;
        }
    }
}
