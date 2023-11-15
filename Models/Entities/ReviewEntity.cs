using System.ComponentModel.DataAnnotations;

namespace Project_Course_Submission.Models.Entities
{
	public class ReviewEntity
	{
		[Key]
		public int Id { get; set; }
		public DateTime CommentCreated { get; set; } = DateTime.Now;
		public int Rating { get; set; }
		public string? Comment { get; set; } = null!;

		public ICollection<ProductReviewEntity> Products { get; set; } = new HashSet<ProductReviewEntity>();
		
	}
}
