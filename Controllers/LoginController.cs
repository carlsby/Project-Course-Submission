using Microsoft.AspNetCore.Mvc;

namespace Project_Course_Submission.Controllers
{
	public class LoginController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}

        public IActionResult ForgotPassword()
        {
            return View();
        }
    }
}
