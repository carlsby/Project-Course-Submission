namespace Project_Course_Submission.ViewModels
{
	public class LatestProductsViewModel
	{
		public string Title { get; set; } = "";
		public IEnumerable<LatestProductsItemViewModel> LatestItems { get; set; } = null!;
	}
}