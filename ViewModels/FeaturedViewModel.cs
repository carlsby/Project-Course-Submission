namespace Project_Course_Submission.ViewModels
{
	public class FeaturedViewModel
	{
		public string Title { get; set; } = "";
        public string Ingress { get; set; } = "";
        public IEnumerable<FeaturedItemViewModel> FeaturedItems { get; set; } = null!;
	}
}
