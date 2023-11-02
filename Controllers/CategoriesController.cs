using Microsoft.AspNetCore.Mvc;

namespace Project_Course_Submission.Controllers
{
	public class CategoriesController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}

		public IActionResult Details()
		{
			return View();
		}
	}
}
