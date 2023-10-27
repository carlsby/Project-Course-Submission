using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Project_Course_Submission.Contexts;
using Project_Course_Submission.Models.Entities;
using Microsoft.AspNetCore.Hosting;
using Project_Course_Submission.Migrations.Data;
using ImageEntity = Project_Course_Submission.Migrations.Data.ImageEntity;

namespace Project_Course_Submission.Services.Repositories;

public class ProductRepository : TEntityRepository<ProductEntity>
{
    private readonly DataContext _context;
    private readonly IWebHostEnvironment _webHostEnvironment;
	public ProductRepository(DataContext context,IWebHostEnvironment webHostEnvironment) : base(context)
    {
        _context = context;
        _webHostEnvironment = webHostEnvironment;
    }



	#region GetAllAsync
	public override async Task<IEnumerable<ProductEntity>> GetAllAsync()
    {
        var items = await _context.Products
            .Include(x => x.Tags)
            .ThenInclude(x => x.Tag)
            .Include(x => x.Categories)
            .ThenInclude(x => x.Category)
            .Include(x => x.Images)
            .ThenInclude(x => x.Image)
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
    public async Task<IEnumerable<string>> GetCategoriesAsync()
    {
        var categoryNames = await _context.Products
            .SelectMany(product => product.Categories.Select(category => category.Category.CategoryName))
            .ToListAsync();

        return categoryNames;
    }
    #endregion

    #region GetAllCategoriesAsync
    public async Task<IEnumerable<CategoryEntity>> GetAllCategoriesAsync()
    {
        return await _context.Categories.ToListAsync();
    }
	#endregion




}
