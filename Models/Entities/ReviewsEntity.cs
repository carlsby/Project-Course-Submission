using System.ComponentModel.DataAnnotations;

namespace Project_Course_Submission.Models.Entities
{
    public class ReviewsEntity
    {
        [Key]
        public int Id { get; set; }
        public DateTime CommentCreated { get; set; }
        public string Comment { get; set; } = null!;
        public UserProfileEntity? UserId { get; set; }
    }
}
