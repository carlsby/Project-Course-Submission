using Microsoft.EntityFrameworkCore;
using Project_Course_Submission.Models.Entities;

namespace Project_Course_Submission.Contexts
{
	public class DataContext : DbContext
	{
        public DataContext()
        {
        }

        public DataContext(DbContextOptions<DataContext> options) : base(options) 
		{
		}

		public DbSet<CategoryEntity> Categories { get; set; }
		public DbSet<CategoryImageEntity> CategoryImages { get; set; }
		public DbSet<ProductCategoryEntity> ProductCategories { get; set; }
		public DbSet<ProductImageEntity> ProductImages { get; set; }
		public DbSet<ImageEntity> Images { get; set; }
		public DbSet<ProductReviewEntity> ProductReviews { get; set; }
		public DbSet<ReviewEntity> Reviews { get; set; }
		public DbSet<ProductTagEntity> ProductTags { get; set; }
		public DbSet<TagEntity> Tags { get; set; }
		public DbSet<ProductEntity> Products { get; set; }

	}
}
