namespace Project_Course_Submission.ViewModels
{
   public class CollectionDetailViewModel
    {
        public string Title { get; set; } = "Detailpage";
        public BestSellersViewModel BestSellers { get; set; } = null!;
        public FeaturedViewModel FeaturedProducts { get; set; } = null!;
    }
}