using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project_Course_Submission.Contexts;
using Project_Course_Submission.ViewModels;
using System.Security.Claims;

namespace Project_Course_Submission.Controllers
{
    public class OrderHistoryController : Controller
    {
        private readonly DataContext _context;
        public OrderHistoryController(DataContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult History()
        {
            string loggedInUserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrEmpty(loggedInUserId))
            {
                
                return RedirectToAction("Login"); 
            }

            // hämtar data
            var orderHistoryData = _context.Orders
                .Where(o => o.UserId == loggedInUserId)
                .Select(o => new OrderHistoryViewModel
                {
                    OrderId = o.Id,
                    OrderDate = o.OrderDate,
                    OrderStatus = o.OrderStatus,
                    TotalAmount = o.TotalPrice,
                    OrderItems = o.OrderItems.Select(oi => new OrderItemViewModel
                    {
                        ProductName = oi.ProductName,
                        Size = oi.Size,
                        Color = oi.Color,
                        Quantity = oi.Quantity,
                        Price = oi.Price
                    }).ToList()
                })
                .ToList();

            return View("Views/Partials/OrderHistory/_History.cshtml", orderHistoryData);
        }
    }
}
