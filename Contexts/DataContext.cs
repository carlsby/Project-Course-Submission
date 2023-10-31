using Microsoft.EntityFrameworkCore;
using Project_Course_Submission.Entities;
using Project_Course_Submission.Models.Entities;

namespace Project_Course_Submission.Contexts
{
	public class DataContext : DbContext
	{

       
        public DataContext(DbContextOptions<DataContext> options) : base(options) 
		{
		}

        public DataContext()
        {
        }
        public DbSet<WishlistsEntity> Wishlist { get; set; }
        public DbSet<OrderTrackEntity> Tracks { get; set; }
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
        public DbSet<OrderEntity> Orders { get; set; }

    }
}

