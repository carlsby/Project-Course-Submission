using Microsoft.EntityFrameworkCore;
using Project_Course_Submission.Contexts;
using Project_Course_Submission.Models;

namespace Project_Course_Submission.Services
{
    public class ReviewService
    {
        private readonly DataContext _context;

        public ReviewService(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ReviewModel>> GetAllAsync()
        {
            var reviews = await _context.Reviews
                .Select(review => new ReviewModel
                {
                    Id = review.Id,
                    CommentCreated = review.CommentCreated,
                    Rating = review.Rating,
                    Comment = review.Comment
                })
                .ToListAsync();

            return reviews;
        }
    }
}