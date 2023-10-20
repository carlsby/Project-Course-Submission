namespace Project_Course_Submission.Models.Entities;

public class CategoryEntity
{
    public int Id { get; set; }
    public string CategoryName { get; set; } = null!;
    public string CategoryImage { get; set; } = null!;
	public ICollection<ProductCategoryEntity> Products { get; set; } = new HashSet<ProductCategoryEntity>();


    
    }

