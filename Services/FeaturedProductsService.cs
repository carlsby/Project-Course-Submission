using Project_Course_Submission.ViewModels;

namespace Project_Course_Submission.Services
{
    public class FeaturedProductsService
    {

        private readonly FeaturedViewModel _featured = new()
        {
            Title = "Featured Products",
            Ingress = "View All",
            FeaturedItems = new List<FeaturedItemViewModel>
            {
                new FeaturedItemViewModel { Id = "1", Title = "Soft Chill Pants", Price = 30, ImageUrl = "/images/featured/200x122.svg"},
                new FeaturedItemViewModel { Id = "2", Title = "Short Warm Jacket", Price = 30, ImageUrl = "/images/featured/200x122.svg" },
                new FeaturedItemViewModel { Id = "3", Title = "Short Pocket Jacket", Price = 30, ImageUrl = "/images/featured/200x122.svg" },
                new FeaturedItemViewModel { Id = "4", Title = "Suit Pants", Price = 30, ImageUrl = "/images/featured/200x122.svg" },
                new FeaturedItemViewModel { Id = "5", Title = "Perfect Padded Jacket", Price = 30, ImageUrl = "/images/featured/200x122.svg" },
                new FeaturedItemViewModel { Id = "6", Title = "Knit Sweater", Price = 30, ImageUrl = "/images/featured/200x122.svg" },
                new FeaturedItemViewModel { Id = "7", Title = "Premium Boots", Price = 30, ImageUrl = "/images/featured/200x122.svg" }
            }
        };

        public FeaturedViewModel GetFeaturedProducts()
        {
            return _featured;
        }
    }
}
