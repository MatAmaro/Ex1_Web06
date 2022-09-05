using System.Data;

namespace ApiClientes.Core.Interfaces
{
    public interface IConnectionDataBase
    {
        IDbConnection CreateConnection();
    }
}