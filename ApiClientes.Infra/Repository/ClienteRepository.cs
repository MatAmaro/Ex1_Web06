using ApiClientes.Core.Interfaces;
using ApiClientes.Core.Models;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
namespace ApiClientes.Infra.Repository
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly IConfiguration _configuration;

        public ClienteRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        public List<Cliente> GetClients()
        {
            var query = "SELECT * FROM clientes";

            using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            return conn.Query<Cliente>(query).ToList();
        }

        public bool InsertClient(Cliente client)
        {
            var query = "INSERT INTO clientes VALUES(@cpf, @nome, @datanascimento, @idade)";
            var parameters = new DynamicParameters();
            parameters.Add("cpf", client.cpf);
            parameters.Add("nome", client.Nome);
            parameters.Add("datanascimento", client.DataNascimento);
            parameters.Add("idade", client.Idade);
            using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

            return conn.Execute(query, parameters) == 1;
        }

        public bool UpdateClient(string cpf, Cliente client)
        {
            var query = @"Update clientes
SET cpf = @cpf, nome = @name, dataNascimento = @birthdate, idade = @age
WHERE cpf = @InputCpf";
            var parameters = new DynamicParameters();
            parameters.Add("cpf", client.cpf);
            parameters.Add("name", client.Nome);
            parameters.Add("birthdate", client.DataNascimento);
            parameters.Add("age", client.Idade);
            parameters.Add("InputCpf", cpf);

            using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            return (conn.Execute(query, parameters) == 1);
        }

        public bool DeleteClient(string cpf)
        {
            var query = "DELETE FROM clientes WHERE cpf = @cpf";
            var parameters = new DynamicParameters(new { cpf });
            using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            return (conn.Execute(query, parameters) == 1);
        }

        public Cliente GetClientByCpf(string cpf)
        {
            var query = "SELECT * FROM clientes WHERE cpf = @cpf";
            var parameters = new DynamicParameters(new { cpf });
            using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            return conn.QueryFirstOrDefault<Cliente>(query, parameters);
        }

    }
}
