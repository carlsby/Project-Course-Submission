using Project_Course_Submission.ViewModels;

namespace Project_Course_Submission.Services
{
	public class BestSellersService
	{
        private readonly BestSellersViewModel _bestSellers = new()
        {
            Title = "Best Sellers",
            Ingress = "View All",
            BestItems = new List<BestSellersItemViewModel>
            { 
                new BestSellersItemViewModel { Id = "1", Title = "Welcome To Manero", Description = "Stretchigt, mjukt material. Vikning i midjan, utsvängda byxben.", Price = 40, ImageUrl = "/images/bestsellers/270x295.svg"},
				new BestSellersItemViewModel { Id = "2", Title = "Short Warm Jacket", Description = "Dubbelknäppning på framsidan. Lång, rak ärm med en slejf vid ärmslutet.", Price = 300, ImageUrl = "/images/bestsellers/270x295.svg" },
				new BestSellersItemViewModel { Id = "3", Title = "Short Pocket Jacket", Description = "Knappar framtill. Lång ärm med en slejf vid ärmslutet", Price = 50, ImageUrl = "/images/bestsellers/270x295.svg" },
				new BestSellersItemViewModel { Id = "4", Title = "Suit Pants", Description = "Mjukt, stretchigt material i trikå. Hällor. Byxor med vida ben.", Price = 40, ImageUrl = "/images/bestsellers/270x295.svg" },
				new BestSellersItemViewModel { Id = "5", Title = "Perfect Padded Jacket", Description = "Huva med piléfoder och en dragsko. Fickor på sidorna med tryckknapp", Price = 500, ImageUrl = "/images/bestsellers/270x295.svg" },
				new BestSellersItemViewModel { Id = "6", Title = "Knit Sweater", Description = "Mjukt, stretchigt material. Rak, vid modell med en ribbmudd i nederkant.", Price = 20, ImageUrl = "/images/bestsellers/270x295.svg" },
				new BestSellersItemViewModel { Id = "7", Title = "Premium Boots", Description = "Mockaliknande material. Fodrad insida.", Price = 60, ImageUrl = "/images/bestsellers/270x295.svg" }
			}
        };

        public BestSellersViewModel GetBestSellers()
        {
            return _bestSellers;
        }

        public BestSellersItemViewModel GetProductById(string id)
        {
            // Hämta listan av "Best Sellers" produkter från BestSellersViewModel
            var bestSellers = _bestSellers.BestItems;

            // Sök efter produkten med matchande ID
            var product = bestSellers.FirstOrDefault(p => p.Id == id);

            // Returnera produkten om den hittades, annars returnera null
            return product!;
        }
    }
}
