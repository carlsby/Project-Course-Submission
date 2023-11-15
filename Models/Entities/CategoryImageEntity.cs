namespace Project_Course_Submission.Models.Entities
{
	public class CategoryImageEntity
	{
		public int Id { get; set; }

		public int CategoryId { get; set; }
		public CategoryEntity Category { get; set; } = null!;

		
		public int ImageId { get; set; }
		public ImageEntity Image { get; set; } = null!;
	}
}
