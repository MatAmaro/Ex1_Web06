using ApiClientes.Core.Interfaces;
using ApiClientes.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ApiClientes.Filters
{
    public class ActionFilterCpfUpdate : ActionFilterAttribute
    {
        private readonly IClienteService _clientService;

        public ActionFilterCpfUpdate(IClienteService clienteService)
        {
            _clientService = clienteService;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            Cliente client = (Cliente)context.ActionArguments["client"];
            string cpf = client.cpf;
            if (_clientService.GetClienteByCpf(cpf) == null)
            {
                context.Result = new StatusCodeResult(StatusCodes.Status400BadRequest);
            }
        }
    }
}
