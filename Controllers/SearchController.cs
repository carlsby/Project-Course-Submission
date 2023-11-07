using Microsoft.AspNetCore.Mvc;

namespace Project_Course_Submission.Controllers
{
    public class SearchController : Controller
    {

        private List<string> Categories = new List<string> { "T-shirts", "Shirts", "Blouses", "Sweaters", "Jackets", "Coats", "Vests", "Hoodies", "Jeans", "Trousers", "Shorts", "Shoes", "kids" };

        public IActionResult Index(string searchText)
        {
            // Om inget sökord anges visas hela listan
            if (string.IsNullOrEmpty(searchText))
            {
                return View(Categories);
            }

            // Annars visas endast kategorier som innehåller sökordet
            var result = Categories.Where(c => c.ToLower().Contains(searchText.ToLower())).ToList();

            // Om det inte finns någon kategori som innehåller sökordet, visas en lista med en enda sträng som anger att denna kategori inte finns

            if (!result.Any())
            {
                result = new List<string> { "Your search didn't match any category." };

                return View(result);
            }

            return View(result);
        }
    }
}
