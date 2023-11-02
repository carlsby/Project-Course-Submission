using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Project_Course_Submission.Models.Entities
{
  
      [PrimaryKey("ArticleNumber", "ReviewId")]
  public class ProductReviewEntity
    {
		public string ArticleNumber = null!;
		public ProductEntity Product { get; set; } = null!;
		public int ReviewId { get; set; }
		public ReviewEntity Review { get; set; } = null!;
	}
}
