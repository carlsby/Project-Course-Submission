using Project_Course_Submission.ViewModels;

namespace Project_Course_Submission.Services
{
    public class LatestProductsService
    {
            private readonly LatestProductsViewModel _latest = new()
            {
                
                LatestItems = new List<LatestProductsItemViewModel>
            {
                new LatestProductsItemViewModel { Id = "1", Title = "Welcome To Manero", ImageUrl = "/images/softpants.jpg", ButtonUrl = "Shop Now" },
                new LatestProductsItemViewModel { Id = "2", Title = "Christmas Gifts", ImageUrl = "/images/christmasgifts.jpg", ButtonUrl = "Find Gifts" },
                new LatestProductsItemViewModel { Id = "3", Title = "Winter Collection", ImageUrl = "/images/winter.jpg", ButtonUrl = "See More" },
                new LatestProductsItemViewModel { Id = "4", Title = "Winter Is Coming", ImageUrl = "/images/christmas.jpg", ButtonUrl = "See More" },
            }
        };

            public LatestProductsViewModel GetLatestProducts()
            {
                return _latest;
            }

            public LatestProductsItemViewModel GetProductById(string id)
            {
                
                var latest = _latest.LatestItems;

                // Sök efter produkten med matchande ID
                var product = latest.FirstOrDefault(p => p.Id == id);

                // Returnera produkten om den hittades, annars returnera null
                return product!;
            }
        }
    }


