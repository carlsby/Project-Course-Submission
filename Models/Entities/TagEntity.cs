namespace Project_Course_Submission.Models.Entities;

public class TagEntity
{
	public int Id { get; set; }
	public string TagName { get; set; } = null!;
	public ICollection<ProductTagEntity> Products { get; set; } = new HashSet<ProductTagEntity>();
}
