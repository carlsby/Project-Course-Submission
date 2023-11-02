using Project_Course_Submission.Models.Entities;
using System;

namespace Project_Course_Submission.ViewModels
{
    public class ReviewViewModel
    {
        public int Id { get; set; }
        public DateTime CommentCreated { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }

        public static ReviewViewModel FromEntity(ReviewEntity entity)
        {
            return new ReviewViewModel
            {
                Id = entity.Id,
                CommentCreated = entity.CommentCreated,
                Rating = entity.Rating,
                Comment = entity.Comment,
            };
        }
    }
}