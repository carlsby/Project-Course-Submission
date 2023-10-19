
using Microsoft.AspNetCore.Mvc;
using Project_Course_Submission.Services;
using Project_Course_Submission.ViewModels;

namespace Project_Course_Submission.Controllers
{
    public class HomeController : Controller
    {
        private readonly BestSellersService _bestSellersService;
        private readonly FeaturedProductsService _featuredProductsService;

        public HomeController(BestSellersService bestSellersService, FeaturedProductsService featuredProductsService)
        {
            _bestSellersService = bestSellersService;
            _featuredProductsService = featuredProductsService;
        }

        public IActionResult Index()
        {
            var viewModel = new HomeIndexViewModel
            {
                Title = "Home",
                BestSellers = _bestSellersService.GetBestSellers(),
                FeaturedProducts = _featuredProductsService.GetFeaturedProducts()
            };
            return View(viewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}