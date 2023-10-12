using Microsoft.AspNetCore.Mvc;

namespace Project_Course_Submission.Controllers
{
	public class AccountController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
