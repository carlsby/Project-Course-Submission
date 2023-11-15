namespace Project_Course_Submission.ViewModels
{
	public class FeaturedItemViewModel
	{
		public string Id { get; set; } = null!;
		public string ImageUrl { get; set; } = null!;
		public string Title { get; set; } = null!;
		public string Description { get; set; } = null!;
		public decimal Price { get; set; }
	}
}