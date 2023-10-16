using Microsoft.AspNetCore.Mvc;
using Project_Course_Submission.Services;
using Project_Course_Submission.ViewModels;

namespace Project_Course_Submission.Controllers
{
	public class RegisterController : Controller
	{

        private readonly AuthService _auth;

        public RegisterController(AuthService auth)
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
                if (await _auth.RegisterAsync(model))
                {
                    return RedirectToAction("Index", "Login");
                }

                ModelState.AddModelError("", "A user with the same email already exits.");
            }

            return View(model);
        }
    }
}
