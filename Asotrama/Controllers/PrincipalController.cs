using Microsoft.AspNetCore.Mvc;

namespace Asotrama.Controllers
{
    public class PrincipalController : Controller
    {
        public IActionResult Principal()
        {
            if (HttpContext.Session.GetString("validationLogin") != null)
            {
                return View();
            }
            return RedirectToAction("Login", "Login");
        }

    }
}
