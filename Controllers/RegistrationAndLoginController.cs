using Microsoft.AspNetCore.Mvc;
using LearningLanguagePlatform.ViewModels;
using Microsoft.AspNetCore.Identity;
using LearningLanguagePlatform.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace LearningLanguagePlatform.Controllers
{
    public class RegistrationAndLoginController : Controller
    {
        private readonly SignInManager<User> signInManager;
        private readonly UserManager<User> userManager;

        public RegistrationAndLoginController(SignInManager<User> signInManager, UserManager<User> userManager)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LoginAsync(LoginVM model)
        {
            if(ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(model.Email,model.Password!, false, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    return RedirectToAction("WelcomePage", "Home");
                }

                ModelState.AddModelError("", "Invalid login attempt");
                return View(model);
            }
            return View(model);
        }

        public IActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Registration(RegisterVM model)
        {
            if (ModelState.IsValid)
            {
                User user = new()
                {
                    UserName = model.Email,
                    Name = model.Name,
                    SelectedLanguage = model.SelectLanguage,    
                    Email = model.Email,
                };

                var result = await userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    if (user.Email == "ahmed@admin.com")
                    {
                        await userManager.AddToRoleAsync(user, "Admin");
                    }
                    else
                    {
                        await userManager.AddToRoleAsync(user, "User");
                    }

                    await signInManager.SignInAsync(user, false);
                    return RedirectToAction("Login", "RegistrationAndLogin");
                }
                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Login", "RegistrationAndLogin");
        }
    }
}
