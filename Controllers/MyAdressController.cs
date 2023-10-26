using Microsoft.AspNetCore.Mvc;

namespace Project_Course_Submission.Controllers
{
    public class MyAdressController : Controller
    {
        public IActionResult Index()
        {
            return View("Views/Partials/MyAdress/_MyAdress.cshtml");
        }
    }
}
