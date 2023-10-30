using Microsoft.AspNetCore.Mvc;
using Project_Course_Submission.Services;
using Project_Course_Submission.Services.Repositories;
using Project_Course_Submission.ViewModels;

namespace Project_Course_Submission.Controllers
{
	public class ProductsController : Controller
	{
		
        private readonly ProductRepository _productRepository;
	
		public ProductsController(ProductRepository productRepository)
		{
			_productRepository = productRepository;
		}
		public async Task<ActionResult> Index()
        {
	
			var products = await _productRepository.GetAllAsync();
			var viewModel = new ProductIndexViewModel
			{
				Products = products,
				Title = "Products",
				
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
