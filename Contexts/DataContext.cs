using Microsoft.EntityFrameworkCore;
using Project_Course_Submission.Models.Entities;

namespace Project_Course_Submission.Contexts
{
	public class DataContext : DbContext
	{
		public DataContext(DbContextOptions<DataContext> options) : base(options) 
		{
		}

		public DbSet<CategoryEntity> Categories { get; set; }
		public DbSet<ProductCategoryEntity> ProductCategories { get; set; }
		public DbSet<ProductImageEntity> ProductImages { get; set; }
		public DbSet<ReviewsEntity> Reviews { get; set; }
		public DbSet<TagEntity> Tags { get; set; }
		public DbSet<ProductEntity> Products { get; set; }
	}
}
