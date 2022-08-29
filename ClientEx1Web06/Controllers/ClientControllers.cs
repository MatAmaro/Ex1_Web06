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
        public List<Client> UpdateClient(string cpf, Client client)
        {
            int index = Clients.IndexOf(Clients.FirstOrDefault(cli => cli.Cpf == cpf));
            List<Client> clientUpdate = new() { Clients[index] };            
            Clients[index] = client;
            clientUpdate.Add(Clients[index]);
            return clientUpdate;
        }

        [HttpDelete]
        public List<Client> DeleteClient(string cpf)
        {
            int index = Clients.IndexOf(Clients.FirstOrDefault(cli => cli.Cpf == cpf));
            Clients.RemoveAt(index);
            return Clients;
        }
    }
}
