using Microsoft.AspNetCore.Mvc;

namespace ClientEx1Web06.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Consumes("application/json")]
    [Produces("application/json")]
    public class ClienttControllers : ControllerBase
    {

        public static List<Client> Clients { get; set; } = new()
        {
            { new Client("12345678909", "Ricardo", DateTime.Parse("07/11/2001")) },
            { new Client("98765432111", "Daniel", DateTime.Parse("15/10/1996")) },
            { new Client("87445954857", "Vera", DateTime.Parse("15/11/1984")) },
            { new Client("16562675299", "Marcus", DateTime.Parse("03/04/2003")) },
            { new Client("55478941544", "Matheus", DateTime.Parse("05/06/2002")) }

        };

        

        [HttpGet("clientes/consultar")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<List<Client>> Consulta()
        {
            return Ok(Clients);
        }



        [HttpGet("clientes/{cpf}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Client> Consulta(string cpf)
        {          
            if(!Clients.Any(cli => cli.Cpf == cpf))
            {
                return NotFound();
            }
            Client client = Clients.Find(cli => cli.Cpf == cpf);
            return Ok(client);
        }



        [HttpPost("clientes/Inserir")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public ActionResult<List<Client>> InsertClient(Client client)
        {
            Clients.Add(client);
            return Clients;
        }



        [HttpPut("clientes/{cpf}/Atualizar")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<List<Client>> UpdateClient(string cpf, Client client)
        {
            if (!Clients.Any(cli => cli.Cpf == cpf))
            {
                return NotFound();
            }
            int index = Clients.FindIndex(cli => cli.Cpf == cpf);
            List<Client> clientUpdate = new() { Clients[index] };            
            Clients[index] = client;
            clientUpdate.Add(Clients[index]);
            return Accepted(clientUpdate);
        }



        [HttpDelete("clientes/{cpf}/Deletar")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DeleteClient(string cpf)
        {
            if (!Clients.Any(cli => cli.Cpf == cpf))
            {
                return NotFound();
            }
            Client client = Clients.Find(cli => cli.Cpf == cpf);
            Clients.Remove(client);
            return NoContent();
        }
    }
}
