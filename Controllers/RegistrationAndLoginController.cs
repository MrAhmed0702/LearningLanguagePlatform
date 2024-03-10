using Microsoft.AspNetCore.Mvc;

namespace LearningLanguagePlatform.Controllers
{
    public class RegistrationAndLoginController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Registration()
        {
            return View();
        }
    }
}
