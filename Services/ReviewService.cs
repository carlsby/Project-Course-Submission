using Microsoft.EntityFrameworkCore;
using Project_Course_Submission.Contexts;
using Project_Course_Submission.Models;

namespace Project_Course_Submission.Services;

public class ReviewService
{
    private readonly DataContext _context;
public ReviewService(DataContext context)
    {
        _context = context;
    }


    public async Task<IEnumerable<ReviewModel>> GetAllAsync()
    {
        var reviews = new List<ReviewModel>();
        var item = await _context.Reviews.ToListAsync();

        foreach (var review in item)
        {
            ReviewModel reviewModel = review;
            reviews.Add(reviewModel);
        }

        return reviews;
    }

}

