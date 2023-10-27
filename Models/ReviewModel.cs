namespace Project_Course_Submission.Models
{
    public class ReviewModel
    {

        public int? Id { get; set; }
        public DateTime CommentCreated { get; set; }
        public int? Rating { get; set; }
        public string? Comment { get; set; }

    }
}
