
using Microsoft.AspNetCore.Mvc;
using Project_Course_Submission.Services;
using Project_Course_Submission.ViewModels;

namespace Project_Course_Submission.Controllers
{
    public class HomeController : Controller
    {
        private readonly BestSellersService _bestSellersService;

        public HomeController(BestSellersService bestSellersService)
        {
            _bestSellersService = bestSellersService;
        }

        public IActionResult Index()
        {
            var viewModel = new HomeIndexViewModel
            {
                Title = "Home",
                BestSellers = _bestSellersService.GetBestSellers()
            };
            return View(viewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}