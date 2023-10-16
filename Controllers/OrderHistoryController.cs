using Microsoft.AspNetCore.Mvc;

namespace Project_Course_Submission.Controllers
{
    public class OrderHistoryController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult History()
        {
            // Your action logic here
            return View("_History"); // Assumes "_History.cshtml" is located in the Views folder
        }
    }
}
