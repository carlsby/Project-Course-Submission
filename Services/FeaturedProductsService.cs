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
                new FeaturedItemViewModel { Id = "1", Title = "Christmas Tree, Green", Description = "Verklighetstrogen julgran i mörkgrön färg. 200 cm hög.", Price = 300, ImageUrl = "/images/featured/200x122.svg"},
                new FeaturedItemViewModel { Id = "2", Title = "Long Puffer Coat", Description = "Fodrad vadderad jacka. Dragkedje- och tryckknappsstängning framtill.", Price = 99, ImageUrl = "/images/featured/200x122.svg" },
                new FeaturedItemViewModel { Id = "3", Title = "Short Pocket Jacket", Description = "Knappar framtill, fickor framtill. Krage vid halsen.", Price = 30, ImageUrl = "/images/featured/200x122.svg" },
                new FeaturedItemViewModel { Id = "4", Title = "6-pack Christmas Ornaments", Description = "Vackra papperornaments i 6-pack. 7,5 cm bred.", Price = 13, ImageUrl = "/images/featured/200x122.svg" },
                new FeaturedItemViewModel { Id = "5", Title = "Warm-Lined Boots", Description = "Chelsea-modell, rundad tå. Breda resårpartier i sidorna.", Price = 34, ImageUrl = "/images/featured/200x122.svg" },
                new FeaturedItemViewModel { Id = "6", Title = "Running Tights", Description = "Stretchig kvalitet. Resår och dragsko i midja.", Price = 34, ImageUrl = "/images/featured/200x122.svg" },
                new FeaturedItemViewModel { Id = "7", Title = "Jute Doormat", Description = "Dörrmatta, jute 100%. 50x70 cm.", Price = 26, ImageUrl = "/images/featured/200x122.svg" }
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
