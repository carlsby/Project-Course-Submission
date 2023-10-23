
using Microsoft.AspNetCore.Mvc;
using Project_Course_Submission.Migrations.Data;
using Project_Course_Submission.Services;
using Project_Course_Submission.Services.Repositories;
using Project_Course_Submission.ViewModels;
using static System.Net.Mime.MediaTypeNames;

namespace Project_Course_Submission.Controllers
{
    public class HomeController : Controller
    {
        private readonly BestSellersService _bestSellersService;
        private readonly FeaturedProductsService _featuredProductsService;
        private readonly ProductRepository _productRepository;
        private readonly ProductService _productService;



        public HomeController(BestSellersService bestSellersService, FeaturedProductsService featuredProductsService, ProductRepository productRepository, ProductService productService)
        {
            _bestSellersService = bestSellersService;
            _featuredProductsService = featuredProductsService;
            _productRepository = productRepository;
            _productService = productService;
        }

        public async Task<IActionResult> Index()
        {
			var categoryImages = await _productService.GetCategoryImagesAsync();
			var categoryName = await _productService.GetCategoriesAsync();

			var categoryItems = categoryName.Select(categoryName =>
		new CategoryItemViewModel
		{
            CategoryName = categoryName,
            

        }).ToList();

			var viewModel = new HomeIndexViewModel
			{
				Title = "Home",
                Categories = categoryItems,
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


//public async Task<IActionResult> Index()
//{
//    var categoryName = await _productService.GetCategoriesAsync();
//    var categoryItems = categoryName.Select(categoryName =>
//    new CategoryItemViewModel
//    {
//        CategoryName = categoryName
//    }).ToList();
//    var viewModel = new HomeIndexViewModel
//    {
//        Title = "Home",
//        Categories = categoryItems,
//        BestSellers = _bestSellersService.GetBestSellers(),
//        FeaturedProducts = _featuredProductsService.GetFeaturedProducts()
//    };
//    return View(viewModel);

//}