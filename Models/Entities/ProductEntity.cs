using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project_Course_Submission.Models.Entities
{
	public class ProductEntity
	{
		[Key]
		public string ArticleNumber { get; set; } = null!;
		public string? ProductName { get; set; }
		public string Color { get; set; } = null!;
		public string? Size { get; set; }

		[Column(TypeName = "money")]
		public decimal Price { get; set; }
		public string? Description { get; set; }

		public ICollection<ProductCategoryEntity> Categories { get; set; } = new HashSet<ProductCategoryEntity>();
		public ICollection<ProductImageEntity> Images { get; set; } = new HashSet<ProductImageEntity>();
	}
}
