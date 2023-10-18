using Project_Course_Submission.ViewModels;

namespace Project_Course_Submission.Services
{
	public class BestSellersService
	{
        private readonly BestSellersViewModel _bestSellers = new()
        {
            Title = "Best Sellers",
            BestItems = new List<BestSellersItemViewModel>
            { 
                new BestSellersItemViewModel {Id = "1", Title = "Soft Chill Pants", Price = 30, ImageUrl = "/images/bestsellers/270x295.svg"},
				new BestSellersItemViewModel { Id = "2", Title = "Short Warm Jacket", Price = 30, ImageUrl = "/images/bestsellers/270x295.svg" },
				new BestSellersItemViewModel { Id = "3", Title = "Short Pocket Jacket", Price = 30, ImageUrl = "/images/bestsellers/270x295.svg" },
				new BestSellersItemViewModel { Id = "4", Title = "Suit Pants", Price = 30, ImageUrl = "/images/bestsellers/270x295.svg" },
				new BestSellersItemViewModel { Id = "5", Title = "Perfect Padded Jacket", Price = 30, ImageUrl = "/images/bestsellers/270x295.svg" },
				new BestSellersItemViewModel { Id = "6", Title = "Knit Sweater", Price = 30, ImageUrl = "/images/bestsellers/270x295.svg" },
				new BestSellersItemViewModel { Id = "7", Title = "Premium Boots", Price = 30, ImageUrl = "/images/bestsellers/270x295.svg" }
			}
        };

        public BestSellersViewModel GetBestSellers()
        {
            return _bestSellers;
        }
    }
}
