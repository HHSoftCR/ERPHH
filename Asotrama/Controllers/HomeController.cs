using Asotrama.BusinesLogic.Services;
using Asotrama.DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Asotrama.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly UserService _userService;
        private string connectionString;

        public HomeController(IConfiguration configuration) {
            _configuration = configuration;
            connectionString = _configuration?.GetConnectionString("DefaultConnection") ?? string.Empty;
            _userService = new UserService(connectionString);
        }

        public IActionResult Home()
        {
            if (HttpContext.Session.GetString("validationLogin") != null)
            {
                return View();
            }
            return RedirectToAction("Login", "Login");
        }

        public IActionResult AllUsers()
        {
            List<User?> users = _userService.GetUserInformation();
            return Json(users);
        }
    }
}
