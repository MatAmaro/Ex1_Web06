using ClientEx1Web06.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ClientEx1Web06.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Consumes("application/json")]
    [Produces("application/json")]
    public class ClienttControllers : ControllerBase
    {

        private readonly IConfiguration _configuration;
        public ClientRepository _repository { get; set; }
        public List<Client> ClientList { get; set; }

        public ClienttControllers(IConfiguration configuration)
        {
            _repository = new ClientRepository(configuration);
            ClientList = new List<Client>();

        }

        [HttpGet("clientes/consultar")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<List<Client>> Consulta()
        {

            return Ok(_repository.GetClients());
        }



        [HttpGet("clientes/{cpf}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Client> Consulta(string cpf)
        {
            var client = _repository.GetClientByCpf(cpf);
            if (client == null)
            {
                return NotFound();
            }
            return Ok(client);
        }



        [HttpPost("clientes/Inserir")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult PostClient(Client client)
        {
            if (!_repository.InsertClient(client))
            {
                return BadRequest();
            }
            return CreatedAtAction(nameof(PostClient), client);
        }



        [HttpPut("clientes/{cpf}/Atualizar")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<List<Client>> UpdateClient(string cpf, Client client)
        {
            List<Client> clientUpdate = new();
            Client oldCli = _repository.GetClientByCpf(cpf);
            if(oldCli == null)
            {
                return NotFound();
            }
            clientUpdate.Add(oldCli);
            _repository.UpdateClient(cpf, client);
            clientUpdate.Add(client);
            return Accepted(clientUpdate);
        }



        [HttpDelete("clientes/{cpf}/deletar")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult deleteclient(string cpf)
        {
            if (!_repository.DeleteClient(cpf))
            {
                return NotFound();
            }
           
            return NoContent();
        }
    }
}

