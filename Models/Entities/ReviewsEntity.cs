using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project_Course_Submission.Models.Entities
{
    public class ReviewsEntity
    {
        [Key]
        public int Id { get; set; }
        public DateTime CommentCreated { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; } = null!;
        public UserProfileEntity? UserId { get; set; }

		
        [ForeignKey(nameof(Product))]
		public string ArticleNumber { get; set; } = null!;
		public ProductEntity Product { get; set; } = null!;
	}
}
