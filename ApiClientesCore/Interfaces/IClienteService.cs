using ApiClientes.Core.Models;

namespace ApiClientes.Core.Interfaces
{
    public interface IClienteService
    {
        bool DeleteCliente(string cpf);
        Cliente GetClienteByCpf(string cpf);
        List<Cliente> GetClientes();
        bool InsertCliente(Cliente client);
        bool UpdateCliente(string cpf, Cliente client);
    }
}