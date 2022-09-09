using ApiClientes.Core.Interfaces;
using ApiClientes.Core.Models;
using ApiClientes.Filters;
using Microsoft.AspNetCore.Mvc;

namespace ClientEx1Web06.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Consumes("application/json")]
    [Produces("application/json")]
    [TypeFilter(typeof(ResourceFilterTime))]
    public class ClienttControllers : ControllerBase
    {

        public IClienteService _clienteService;
        
        public ClienttControllers(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpGet("clientes/consultar")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<List<Cliente>> Consulta()
        {
            return Ok(_clienteService.GetClientes());
        }

        [HttpGet("clientes/{cpf}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Cliente> Consulta(string cpf)
        {
            var client = _clienteService.GetClienteByCpf(cpf);
            if (client == null)
            {
                return NotFound();
            }
            return Ok(client);
        }

        [HttpPost("clientes/Inserir")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [TypeFilter(typeof(ActionFilterCpfPost))]
        public IActionResult PostClient(Cliente client)
        {
            if (!_clienteService.InsertCliente(client))
            {
                return BadRequest();
            }
            return CreatedAtAction(nameof(PostClient), client);
        }

        [HttpPut("clientes/{cpf}/Atualizar")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [TypeFilter(typeof(ActionFilterCpfUpdate))]
        public ActionResult<List<Cliente>> UpdateClient(string cpf, Cliente client)
        {
            List<Cliente> clientUpdate = new();
            Cliente oldCli = _clienteService.GetClienteByCpf(cpf);
            if(oldCli == null)
            {
                return NotFound();
            }
            clientUpdate.Add(oldCli);
            _clienteService.UpdateCliente(cpf, client);
            clientUpdate.Add(client);
            return Accepted(clientUpdate);
        }

        [HttpDelete("clientes/{cpf}/deletar")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult deleteclient(string cpf)
        {
            if (!_clienteService.DeleteCliente(cpf))
            {
                return NotFound();
            }
           
            return NoContent();
        }
    }
}

