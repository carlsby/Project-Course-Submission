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
                new BestSellersItemViewModel { Id = "1", Title = "Soft Chill Pants", Price = 40, ImageUrl = "/images/bestsellers/270x295.svg"},
				new BestSellersItemViewModel { Id = "2", Title = "Short Warm Jacket", Price = 300, ImageUrl = "/images/bestsellers/270x295.svg" },
				new BestSellersItemViewModel { Id = "3", Title = "Short Pocket Jacket", Price = 50, ImageUrl = "/images/bestsellers/270x295.svg" },
				new BestSellersItemViewModel { Id = "4", Title = "Suit Pants", Price = 40, ImageUrl = "/images/bestsellers/270x295.svg" },
				new BestSellersItemViewModel { Id = "5", Title = "Perfect Padded Jacket", Price = 500, ImageUrl = "/images/bestsellers/270x295.svg" },
				new BestSellersItemViewModel { Id = "6", Title = "Knit Sweater", Price = 20, ImageUrl = "/images/bestsellers/270x295.svg" },
				new BestSellersItemViewModel { Id = "7", Title = "Premium Boots", Price = 60, ImageUrl = "/images/bestsellers/270x295.svg" }
			}
        };

        public BestSellersViewModel GetBestSellers()
        {
            return _bestSellers;
        }

        public BestSellersItemViewModel GetProductById(string id)
        {
            // Hämta listan av "Best Sellers" produkter från ditt BestSellersViewModel.
            var bestSellers = _bestSellers.BestItems;

            // Sök efter produkten med matchande ID.
            var product = bestSellers.FirstOrDefault(p => p.Id == id);

            // Returnera produkten om den hittades, annars returnera null.
            return product!;
        }
    }
}
