using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project_Course_Submission.Services;
using Project_Course_Submission.ViewModels;

namespace Project_Course_Submission.Controllers
{
    public class LoginController : Controller
    {
        private readonly IAuthService _auth;

        public LoginController(IAuthService auth)
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
                var response = await _auth.LogInAsync(model);

                if (response.StatusCode == Enums.StatusCode.Ok && response.Content)
                {
                    response.StatusCode = Enums.StatusCode.Ok;
                    return RedirectToAction("Index", "Account");
                }
                else
                {
                    response.StatusCode = Enums.StatusCode.BadRequest;
                    ModelState.AddModelError("", "Incorrect email or password.");
                    return View(model);
                }
            }

            return View(model);

        }


        public IActionResult ForgotPassword()
        {
            return View();
        }
    }
}
