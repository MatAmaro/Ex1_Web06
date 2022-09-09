using ApiClientes.Core.Interfaces;
using ApiClientes.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ApiClientes.Filters
{
    public class ActionFilterCpfPost : ActionFilterAttribute
    {
        private readonly IClienteService _clientService;

        public ActionFilterCpfPost(IClienteService clienteService)
        {
            _clientService = clienteService;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            Cliente client = (Cliente)context.ActionArguments["client"];
            string cpf = client.cpf;
            if (_clientService.GetClienteByCpf(cpf) != null)
            {
                context.Result = new StatusCodeResult(StatusCodes.Status409Conflict);
            }
        }
    }
}
