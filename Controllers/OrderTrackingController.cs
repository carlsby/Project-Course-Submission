using Microsoft.AspNetCore.Mvc;
using Project_Course_Submission.Contexts;
using Project_Course_Submission.Models;

namespace Project_Course_Submission.Controllers
{
    public class OrderTrackingController : Controller
    {
        private readonly DataContext _context;

        public OrderTrackingController(DataContext context)
        {
            _context = context;
        }

        public IActionResult Tracking(int orderId)
        {
            var orderTrackingData = _context.Tracks
                .Where(track => track.OrderId == orderId)
                .OrderBy(track => track.TrackId)
                .Select(track => new OrderTrackingStatus
                {
                    TrackLabel = track.TrackLabel,
                    TrackDescription = track.TrackDescription,
                    IsDot = track.IsDot
                })
                .ToList();

            var viewModel = new OrderTrackingViewModel
            {
                TrackingStatuses = orderTrackingData,
                OrderId = orderId 
            };

            return View("Views/Partials/OrderTracking/_Tracking.cshtml", viewModel);
        }
    }
}