namespace Project_Course_Submission.ViewModels
{
    public class BestSellersViewModel
    {
        public string Title { get; set; } = "";
        public string Ingress { get; set; } = "";
        public IEnumerable<BestSellersItemViewModel> BestItems { get; set; } = null!;
    }
}
