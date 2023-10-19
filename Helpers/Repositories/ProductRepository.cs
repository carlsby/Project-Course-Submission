using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Project_Course_Submission.Contexts;
using Project_Course_Submission.Models.Entities;

namespace Project_Course_Submission.Services.Repositories;

public class ProductRepository : TEntityRepository<ProductEntity>
{
    private readonly DataContext _context;
    public ProductRepository(DataContext context) : base(context)
    {
        _context = context;
    }

    #region GetAllAsync
    public override async Task<IEnumerable<ProductEntity>> GetAllAsync()
    {
        var items = await _context.Products
            .Include(x => x.Tags)
            .ThenInclude(x => x.Tag)
            .Include(x => x.Categories)
            .ThenInclude(x => x.Category)
            .ToListAsync();

        return items;
    }
    #endregion

    #region GetAllAsyncExpression
    public override async Task<IEnumerable<ProductEntity>> GetAllAsync(Expression<Func<ProductEntity, bool>> expression)
    {
        var items = await _context.Products
        .Include(x => x.Tags)
        .ThenInclude(x => x.Tag)
        .Include(x => x.Categories)
        .ThenInclude(x => x.Category)
        .Where(expression)
        .ToListAsync();

        return items;
    }

    #endregion

    #region GetAsync

    public override async Task<ProductEntity> GetAsync(Expression<Func<ProductEntity, bool>> expression)
    {
        var item = await _context.Products
            .Include(x => x.Tags)
            .ThenInclude(x => x.Tag)
            .Include(x => x.Categories)
            .ThenInclude(x => x.Category)
            .FirstOrDefaultAsync(expression);

        return item!;
    }
    #endregion

    #region GetCategoriesAsync
    public async Task<IEnumerable<string>> GetCategoryNamesAsync()
    {
        var categoryNames = await _context.Products
            .SelectMany(product => product.Categories.Select(category => category.Category.CategoryName))
            .ToListAsync();

        return categoryNames;
    }
    #endregion

    #region GetAllAsync
    public async Task<IEnumerable<CategoryEntity>> GetAllCategoriesAsync()
    {
        return await _context.Categories.ToListAsync();
    }
    #endregion

}
