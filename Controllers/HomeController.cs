﻿
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
        private readonly ProductService _productService;
        private readonly CategoriesService _categoriesService;



        public HomeController(BestSellersService bestSellersService, FeaturedProductsService featuredProductsService, ProductService productService, CategoriesService categoriesService)
        {
            _bestSellersService = bestSellersService;
            _featuredProductsService = featuredProductsService;
            _productService = productService;
            _categoriesService = categoriesService;
        }

        public async Task<IActionResult> Index()
        {
			
			var categoryName = await _productService.GetCategoriesAsync();
            var categoryImagesId = _categoriesService.GetCategoryImagesId();
			var categoryItems = categoryName.Select(categoryName =>
		new CategoryItemViewModel
		{
            CategoryName = categoryName,
            

        }).ToList();

			var viewModel = new HomeIndexViewModel
			{
				Title = "Home",
                CategoryImagesId = categoryImagesId,
                CategoryImages = _categoriesService.GetCategoryImages(),
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