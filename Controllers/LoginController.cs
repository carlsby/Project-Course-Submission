using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project_Course_Submission.Services;
using Project_Course_Submission.ViewModels;

namespace Project_Course_Submission.Controllers
{
    public class LoginController : Controller
    {
        private readonly AuthService _auth;

        public LoginController(AuthService auth)
        {
            _auth = auth;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserLoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (await _auth.LogInAsync(model))
                {
                    return RedirectToAction("Index", "Account");
                }

                ModelState.AddModelError("", "Incorrect email or password.");
            }

            return View(model);
        }

        public IActionResult ForgotPassword()
        {
            return View();
        }
    }
}
