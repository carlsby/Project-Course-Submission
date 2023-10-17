using AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Project_Course_Submission.Models;
using System.Diagnostics;

namespace Project_Course_Submission.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}