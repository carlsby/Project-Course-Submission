using Microsoft.AspNetCore.Mvc;
using Project_Course_Submission.Services;
using Project_Course_Submission.ViewModels;

namespace Project_Course_Submission.Controllers
{
    public class RegisterController : Controller
    {

        private readonly IAuthService _auth;

        public RegisterController(IAuthService auth)
        {
            _auth = auth;
        }

        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Index(UserRegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _auth.RegisterAsync(model);

                if (result.Content)
                {
                    return RedirectToAction("Index", "Login");
                }

                ModelState.AddModelError("", "A user with the same email already exists.");
            }

            return View(model);
        }

    }
}
