using Microsoft.AspNetCore.Mvc;
using Project_Course_Submission.Services;
using Project_Course_Submission.Services.Repositories;
using Project_Course_Submission.ViewModels;

namespace Project_Course_Submission.Controllers
{
	public class ProductsController : Controller
	{
		
        private readonly ProductRepository _productRepository;
		private readonly ProductService _productService;

		public ProductsController(ProductRepository productRepository, ProductService productService)
		{
			_productRepository = productRepository;
			_productService = productService;
		}
		public async Task<ActionResult> Index()
        {
	
			var products = await _productRepository.GetAllAsync();
            var categoryNames = (await _productRepository.GetCategoriesAsync()).Distinct();
            var categoryItems = categoryNames.Select(categoryName =>
                new CategoryItemViewModel
                {
                    CategoryName = categoryName,
                }).ToList();

            var viewModel = new ProductIndexViewModel
            {
                Products = products,
                Title = "Our Products",
                Categories = categoryItems
            };


            return View(viewModel);
		}

        public async Task<IActionResult> Details(string articleNumber)
        {
            var product = await _productRepository.GetAsync(x => x.ArticleNumber == articleNumber);

            return View(product); 
        }

    }
}
