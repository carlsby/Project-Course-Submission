using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Project_Course_Submission.Controllers
{
	public class AccountController : Controller
	{
		[Authorize]
		public IActionResult Index()
		{
			return View();
		}

		public IActionResult NewPassword()
		{
			return View();
		}
	}
}
