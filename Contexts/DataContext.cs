using Microsoft.EntityFrameworkCore;

namespace Project_Course_Submission.Contexts
{
	public class DataContext : DbContext
	{
		public DataContext(DbContextOptions<DataContext> options) : base(options) 
		{
		}

		public DbSet<ProductEntity> Products { get; set; }
	}
}
