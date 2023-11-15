using System.Security.Cryptography.X509Certificates;

namespace Project_Course_Submission.ViewModels
{
    public class WishlistViewModel
    {
        public int Id { get; set; }
        public string ProductImg { get;set; }
        public string ProductTitle { get; set; }
        public string ProductPrice { get; set; }
        public string ProductReview { get; set; }
        public int ProductReviewRate { get; set; }

        public string ProductsArticleNumber { get; set; }
        public string UserId { get; set; }
    }
}