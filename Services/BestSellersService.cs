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
                new BestSellersItemViewModel {Id = "1", Title = "Apple watch series", Price = 30, ImageUrl = "images/placeholders/270x295.svg"},
				new BestSellersItemViewModel { Id = "2", Title = "Apple watch collection", Price = 30, ImageUrl = "images/placeholders/270x295.svg" },
				new BestSellersItemViewModel { Id = "3", Title = "Apple watch collection", Price = 30, ImageUrl = "images/placeholders/270x295.svg" },
				new BestSellersItemViewModel { Id = "4", Title = "Apple watch collection", Price = 30, ImageUrl = "images/placeholders/270x295.svg" },
				new BestSellersItemViewModel { Id = "5", Title = "Apple watch collection", Price = 30, ImageUrl = "images/placeholders/270x295.svg" },
				new BestSellersItemViewModel { Id = "6", Title = "Apple watch collection", Price = 30, ImageUrl = "images/placeholders/270x295.svg" },
				new BestSellersItemViewModel { Id = "7", Title = "Apple watch collection", Price = 30, ImageUrl = "images/placeholders/270x295.svg" }
			}
        };

        public BestSellersViewModel GetBestSellers()
        {
            return _bestSellers;
        }
    }
}
