using Asotrama.DataAccess.Models;
using Asotrama.DataAccess.Repositories;

namespace Asotrama.BusinesLogic.Services
{
    public class UserService
    {
        private readonly UserRepository _userRepository;

        public UserService(string connectionString)
        {
            _userRepository = new UserRepository(connectionString);
        }

        public bool Login(string username, string password)
        {
            var user = _userRepository.GetUserByUsernameAndPassword(username, password);

            if (user == null)
            {
                return false;
            }

            if (user.Password == password)
            {
                return true;
            }

            return false;
        }

        public List<User?> GetUserInformation()
        {
             return _userRepository.GetAllUsers();
        }
    }
}
