using Microsoft.AspNetCore.Mvc;

namespace ClientEx1Web06.Controllers
{
    [ApiController]
    [Route("[controller]")]
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

        

        [HttpGet]
        public List<Client> Consulta()
        {
            return Clients;
        }

        [HttpPost]
        public List<Client> InsertClient(Client client)
        {
            Clients.Add(client);
            return Clients;
        }

        [HttpPut]
        public List<Client> UpdateClient(int index, Client client)
        {
            List<Client> clientUpdate = new() { Clients[index] };
            clientUpdate[0].Name += "(antigo)";
            Clients[index] = client;
            clientUpdate.Add(client);
            clientUpdate[1].Name += "(atualizado)";
            return clientUpdate;
        }

        [HttpDelete]
        public List<Client> DeleteClient(int index)
        {
            Clients.RemoveAt(index);
            return Clients;
        }
    }
}
