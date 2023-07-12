using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asotrama.Tests
{
    public interface IDbAccess
    {
        ConnectionState ConnectionState { get; }
        void OpenConnection();
        void CloseConnection();
        SqlDataReader ExecuteReader(string commandText, CommandType commandType, SqlParameter[]? parameters = null);
    }
}
