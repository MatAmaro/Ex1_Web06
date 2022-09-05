using ApiClientes.Core.Interfaces;
using ApiClientes.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiClientes.Core.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;
        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public List<Cliente> GetClientes()
        {
            return _clienteRepository.GetClients();
        }

        public Cliente GetClienteByCpf(string cpf)
        {
            return _clienteRepository.GetClientByCpf(cpf);
        }

        public bool InsertCliente(Cliente client)
        {
            return _clienteRepository.InsertClient(client);
        }

        public bool UpdateCliente(string cpf, Cliente client)
        {
            return _clienteRepository.UpdateClient(cpf, client);
        }

        public bool DeleteCliente(string cpf)
        {
            return _clienteRepository.DeleteClient(cpf);
        }
    }
}
