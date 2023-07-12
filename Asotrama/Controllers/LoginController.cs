using Microsoft.AspNetCore.Mvc;
using Asotrama.BusinesLogic.Services;
namespace Asotrama.Controllers
{
    public class Login : Controller
    {
        private readonly ILogger<Login> _logger;
        private readonly IConfiguration _configuration;
        private readonly UserService _userService;
        private string connectionString;
        public Login(ILogger<Login> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
            connectionString = _configuration.GetConnectionString("DefaultConnection") ?? string.Empty;
            _userService = new UserService(connectionString);
        }

        public IActionResult login()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpPost("LoginUser")]
        public IActionResult LoginUser(string username, string password)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            bool isAuthenticated = _userService.Login(username, password);

            if (!isAuthenticated)
            {
                HttpContext.Session.SetString("validationLogin", "false");
                return RedirectToAction("Login", "Login");
            }
            HttpContext.Session.SetString("user", username);
            HttpContext.Session.SetString("validationLogin", "true");
            return RedirectToAction("Home", "Home");
        }

    }
}