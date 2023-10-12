using Project_Course_Submission.Contexts;
using Project_Course_Submission.Models.Entities;

namespace Project_Course_Submission.Repositories;

public class ProductRepository : TEntityRepository<ProductEntity>
{
	private readonly DataContext _context;
	public ProductRepository(DataContext context) : base(context)
	{
		_context = context;
	}



}
