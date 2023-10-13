namespace Project_Course_Submission.Models.Entities
{
	public class ImageEntity
	{
		public int Id { get; set; }
		public string ImageName { get; set; } = null!;

		public ICollection<ProductImageEntity> Products { get; set; } = new HashSet<ProductImageEntity>();
	}
}
