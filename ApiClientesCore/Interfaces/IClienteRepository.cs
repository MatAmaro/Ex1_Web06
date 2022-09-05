
using ApiClientes.Core.Models;

namespace ApiClientes.Core.Interfaces
{
    public interface IClienteRepository
    {
        bool DeleteClient(string cpf);
        Cliente GetClientByCpf(string cpf);
        List<Cliente> GetClients();
        bool InsertClient(Cliente client);
        bool UpdateClient(string cpf, Cliente client);
    }
}