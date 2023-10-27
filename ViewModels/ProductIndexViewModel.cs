namespace Project_Course_Submission.ViewModels
{
	public class ProductIndexViewModel
	{
		public string Title { get; set; } = "Products";
		public ProductDetailViewModel Details { get; set; } = null!;
		public List<string> Tags { get; set; } = new List<string>();
		public List<string> Categories { get; set; } = new List<string>();
	}
}
