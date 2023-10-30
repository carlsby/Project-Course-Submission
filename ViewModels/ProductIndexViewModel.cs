using Project_Course_Submission.Models.Entities;

namespace Project_Course_Submission.ViewModels
{
	public class ProductIndexViewModel
	{
		public IEnumerable<ProductEntity>? Products { get; set; }
        public string Title { get; set; } = "";
		public ProductDetailViewModel Details { get; set; } = null!;
		public List<string> Tags { get; set; } = new List<string>();
		public List<string> Categories { get; set; } = new List<string>();
	}
}
