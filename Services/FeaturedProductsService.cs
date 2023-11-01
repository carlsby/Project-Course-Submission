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
                new FeaturedItemViewModel { Id = "1", Title = "Christmas Tree, Green", Price = 300, ImageUrl = "/images/featured/200x122.svg"},
                new FeaturedItemViewModel { Id = "2", Title = "Long Puffer Coat", Price = 99, ImageUrl = "/images/featured/200x122.svg" },
                new FeaturedItemViewModel { Id = "3", Title = "Short Pocket Jacket", Price = 30, ImageUrl = "/images/featured/200x122.svg" },
                new FeaturedItemViewModel { Id = "4", Title = "6-pack Christmas Ornaments", Price = 13, ImageUrl = "/images/featured/200x122.svg" },
                new FeaturedItemViewModel { Id = "5", Title = "Warm-Lined Boots", Price = 34, ImageUrl = "/images/featured/200x122.svg" },
                new FeaturedItemViewModel { Id = "6", Title = "Running Tights", Price = 34, ImageUrl = "/images/featured/200x122.svg" },
                new FeaturedItemViewModel { Id = "7", Title = "Jute Doormat", Price = 26, ImageUrl = "/images/featured/200x122.svg" }
            }
        };

        public FeaturedViewModel GetFeaturedProducts()
        {
            return _featured;
        }

        public FeaturedItemViewModel GetProductById(string id)
        {
            // Hämta listan av "Best Sellers" produkter från ditt BestSellersViewModel.
            var featuredProducts = _featured.FeaturedItems;

            // Sök efter produkten med matchande ID.
            var product = featuredProducts.FirstOrDefault(p => p.Id == id);

            // Returnera produkten om den hittades, annars returnera null.
            return product!;
        }
    }
}
