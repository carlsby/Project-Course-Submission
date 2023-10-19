namespace Project_Course_Submission.Models.Entities;

public class CategoryEntity
{
    public int Id { get; set; }
    public string CategoryName { get; set; } = null!;

    public ICollection<ProductCategoryEntity> Products { get; set; } = new HashSet<ProductCategoryEntity>();


    public static implicit operator CategoryItem(CategoryEntity entity)
    {
        return new CategoryItem
        {
           CategoryName = entity.CategoryName,
          

        };
    }

}