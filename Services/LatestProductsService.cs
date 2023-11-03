using Project_Course_Submission.ViewModels;

namespace Project_Course_Submission.Services
{
    public class LatestProductsService
    {
            private readonly LatestProductsViewModel _latest = new()
            {
                
                LatestItems = new List<LatestProductsItemViewModel>
            {
                new LatestProductsItemViewModel { Id = "1", Title = "Soft Chill Pants", ImageUrl = "/images/softpants.jpg", ButtonUrl = "Shop Now" },
                
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


