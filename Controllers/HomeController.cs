﻿
using Microsoft.AspNetCore.Mvc;
using Project_Course_Submission.Services;
using Project_Course_Submission.Services.Repositories;
using Project_Course_Submission.ViewModels;

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
			var categoryEntities = await _productService.GetCategoriesAsync();

			var viewModel = new HomeIndexViewModel
			{
				Title = "Home",
				Categories = categoryEntities.Select(category => new CategoryItemViewModel
				{
					CategoryName = category.CategoryName,
					CategoryImage = category.CategoryImage
				}).ToList(),
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