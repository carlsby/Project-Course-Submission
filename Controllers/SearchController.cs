using Microsoft.AspNetCore.Mvc;

namespace Project_Course_Submission.Controllers
{
    public class SearchController : Controller
    {

        private List<string> Categories = new List<string> { "T-shirts", "Shirts", "Blouses", "Sweaters", "Jackets", "Coats", "Vests", "Hoodies", "Jeans", "Trousers", "Shorts", "Shoes", "kids" };

        public IActionResult Index(string searchText)
        {
            
            if (string.IsNullOrEmpty(searchText))
            {
                return View(Categories);
            }

            
            var result = Categories.Where(c => c.ToLower().Contains(searchText.ToLower())).ToList();

            

            if (!result.Any())
            {
                result = new List<string> { "Your search didn't match any category." };

                return View(result);
            }

            return View(result);
        }
    }
}
