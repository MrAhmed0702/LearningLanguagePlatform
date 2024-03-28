using Microsoft.AspNetCore.Mvc;

namespace LearningLanguagePlatform.Controllers
{
    public class UserSelectionController : Controller
    {
        public IActionResult SelectLanguage()
        {
            return View();
        }

        public IActionResult PurposeOflearning()
        {
            return View();
        }

        public IActionResult LanguageKnowledge()
        {
            return View();
        }

        public IActionResult DailyGoals()
        {
            return View();
        }

        public IActionResult WelcomePage()
        {
            return View();
        }
    }
}
