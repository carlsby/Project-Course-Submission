namespace Project_Course_Submission.ViewModels;

public class HomeIndexViewModel
{
    public string Title { get; set; } = "Home";
    public CategoryImagesViewModel CategoryImages { get; set; } = null!;
    public List<CategoryItemViewModel> Categories { get; set; } = new List<CategoryItemViewModel>();
    public List<CategoryImageItemsViewModel> CategoryImagesId { get; set; } = new List<CategoryImageItemsViewModel>();
    public BestSellersViewModel BestSellers { get; set; } = null!;

    public FeaturedViewModel FeaturedProducts { get; set; } = null!;
}
