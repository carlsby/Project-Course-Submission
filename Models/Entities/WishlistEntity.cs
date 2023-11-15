using Microsoft.AspNetCore.Identity;
using Project_Course_Submission.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace Project_Course_Submission.Models.Entities
{
    public class WishlistsEntity
    {
        [Key]
        public int Id { get; set; }
        public string ProductTitle { get; set; }
        public string ProductImg { get; set; }
        public string ProductPrice { get; set; }
        public string ProductReview { get; set; }
        public int ProductReviewRate { get; set; }

        public ProductEntity? Products { get; set; }
        public string ProductsArticleNumber { get; set; }
        public UserProfileEntity User { get; set; }
        public string UserId { get; set; }

    }
}
