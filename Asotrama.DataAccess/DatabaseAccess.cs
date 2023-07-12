using System.Data;
using System.Data.SqlClient;

namespace Asotrama.DataAccess
{
    public class DatabaseAccess : IDisposable
    {
        public ConnectionState ConnectionState => _connection.State;

        private readonly SqlConnection _connection;

        public DatabaseAccess(string connectionString)
        {
            _connection = new SqlConnection(connectionString);
        }

        public void OpenConnection()
        {
            if (_connection.State != ConnectionState.Open)
            {
                _connection.Open();
            }
        }

        public void CloseConnection()
        {
            if (_connection.State != ConnectionState.Closed)
            {
                _connection.Close();
            }
        }

        public SqlDataReader ExecuteReader(string commandText, CommandType commandType, SqlParameter[]? parameters = null)
        {
            using var command = new SqlCommand(commandText, _connection);
            command.CommandType = commandType;

            if (parameters != null)
            {
                command.Parameters.AddRange(parameters);
            }

            return command.ExecuteReader(CommandBehavior.CloseConnection);
        }

        public void Dispose() => throw new NotImplementedException();
    }
}
