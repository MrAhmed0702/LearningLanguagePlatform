using LearningLanguagePlatform.DATA;
using LearningLanguagePlatform.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace LearningLanguagePlatform.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly UserDBContext dBContext;

        public HomeController(UserDBContext dBContext)
        {
            this.dBContext = dBContext;
        }
        public IActionResult WelcomePage()
        {
            return View();
        }

        public IActionResult LearningPage()
        {
            return View();
        }

        public IActionResult Dashboard()
        {
            return View();
        }

        public IActionResult ContactUs()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> ShowUser()
        {
            var users = await dBContext.Registers.ToListAsync();
            return View(users);
        }

        [HttpGet]
        public async Task<IActionResult> EditUser(String Id)
        {
            var users = await dBContext.Registers.FindAsync(Id);

            return View(users);
        }

        [HttpPost]
        public async Task<IActionResult> EditUser(User user)
        {
            var users = await dBContext.Registers.FindAsync(user.Id);

            if (users is not null)
            {
                users.Name = user.Name;
                users.SelectedLanguage = user.SelectedLanguage;
                users.Email = user.Email;

                await dBContext.SaveChangesAsync();
            }

            return RedirectToAction("ShowUser", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var user = await dBContext.Registers.FindAsync(id);

            if (user != null)
            {
                dBContext.Registers.Remove(user);
                await dBContext.SaveChangesAsync();
            }

            return RedirectToAction("ShowUser", "Home");
        }




        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}
