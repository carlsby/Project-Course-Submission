using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Project_Course_Submission.Contexts;

namespace Project_Course_Submission.Repositories;

public abstract class TEntityRepository<TEntity> where TEntity : class
{
	private readonly DataContext _context;

	protected TEntityRepository(DataContext context)
	{
		_context = context;
	}

		#region CreateAsync
	public virtual async Task<TEntity> CreateAsync(TEntity entity)
	{
		_context.Set<TEntity>().Add(entity);
		await _context.SaveChangesAsync();
		return entity;
	}

	#endregion

		#region GetAsync
	public virtual async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> expression)
	{
		try
		{
			var entity = await _context.Set<TEntity>().FirstOrDefaultAsync(expression);
			return entity!;
		}
		catch { return null!; }
	}
	#endregion

		#region GetAllAsync
	public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
	{
		try
		{
			var entity = await _context.Set<TEntity>().ToListAsync();
			return entity!;
		}
		catch { return null!; }
	}
	#endregion

		#region GetAllAsyncExpression
	public virtual async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> expression)
	{
		try
		{
			var entity = await _context.Set<TEntity>().Where(expression).ToListAsync();
			return entity!;
		}
		catch { return null!; }

	}
	#endregion

		#region UpdateAsync
	public virtual async Task<TEntity> UpdateAsync(TEntity entity)
	{
		try
		{
			_context.Set<TEntity>().Update(entity);
			await _context.SaveChangesAsync();

			return entity!;

		}
		catch { return null!; }
	}
	#endregion

		#region DeleteAsync
	public virtual async Task<bool> DeleteAsync(TEntity entity)
	{
		try
		{
			_context.Set<TEntity>().Remove(entity);
			await _context.SaveChangesAsync();
			return true;
		}
		catch { return false; }
	}
	#endregion

}
