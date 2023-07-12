using System.Data;
using Xunit;
using Moq;
using Asotrama.DataAccess.Repositories;
using Asotrama.DataAccess;
using System.Data.SqlClient;
using Asotrama.DataAccess.Models;

namespace Asotrama.Tests
{
    public class UserRepositoryTests
    {
		private UserRepository _userRepository;

		public UserRepositoryTests ()
	{
		_userRepository = new UserRepository("Server=52.3.225.116;Database=Asotrama;User ID=Test;Password=pass23@;");
	}

	[Fact]
	public void GetAllActiveUsers_ReturnsActiveUsers ()
	{

		List<User?> users = _userRepository.GetAllActiveUsers ();

            var userRepository = new UserRepository("Server=52.3.225.116;Database=Asotrama;User ID=Test;Password=pass23@;");
        }
    }
}
