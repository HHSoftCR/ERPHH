using Asotrama.DataAccess.Models;
using System.Data.SqlClient;
using System.Data;
using Asotrama.Tests;

namespace Asotrama.DataAccess.Repositories
{
    public class UserRepository
    {
        private readonly DatabaseAccess _dbAcess;

        public UserRepository(string connectionString)
        {
            _dbAcess = new DatabaseAccess(connectionString);
        }
        public User? GetUserByUsernameAndPassword(string username, string password)
        {
            User? user = null;
            _dbAcess.OpenConnection();
            var commandText = "sp_GetUserByUsernameAndPassword";
            var parameters = new SqlParameter[]
            {
                new SqlParameter("@Username", SqlDbType.VarChar) { Value = username },
                new SqlParameter("@Password", SqlDbType.VarChar) { Value = password }
            };

            using (var reader = _dbAcess.ExecuteReader(commandText, CommandType.StoredProcedure, parameters))
            {
                if (reader.Read())
                {
                    user = new User
                    {
                        Username = reader["usuario"].ToString(),
                        Password = reader["contrasenia"].ToString(),
                    };
                }
            }

            _dbAcess.CloseConnection();
            return user;
        }

        public List<User?> GetAllUsers()
        {
            List<User?> users = new();
            _dbAcess.OpenConnection();
            var commandText = "sp_GetUserInformation";

            using (var reader = _dbAcess.ExecuteReader(commandText, CommandType.StoredProcedure))
            {
                while (reader.Read())
                {
                    User user = new()
                    {
                        Username = reader["usuario"].ToString(),
                        Name = reader["nombreUsuario"].ToString(), 
                        FirstLastname = reader["primerApellido"].ToString(),
                        SecondLastName = reader["segundoApellido"].ToString(),
                        Email = reader["correo"].ToString(),
                        Role = new Role { Name = reader["nombreRol"].ToString() }, 
                        Subsidiary = new Subsidiary { Name = reader["nombre"].ToString() },
                        Status = reader["descripcionEstado"].ToString(),
                        Id = (int?)Convert.ToInt64(reader["idUsuario"].ToString()),
                    };
                    users.Add(user);
                }
            }
            _dbAcess.CloseConnection();
             return users;
        }
    }
}
