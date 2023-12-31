﻿using Microsoft.AspNetCore.Mvc;
using Project_Course_Submission.Contexts; 
using Project_Course_Submission.ViewModels; 
using System.Linq;
using System.Security.Claims;

namespace Project_Course_Submission.Controllers
{
    public class WishlistController : Controller
    {
        private readonly DataContext _context;

        public WishlistController(DataContext context)
        {
            _context = context;
        }
        
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Remove(int id)
        {

            var item = _context.Wishlist.FirstOrDefault(i => i.Id == id);
            _context.Wishlist.Remove(item);
            _context.SaveChanges();


            return RedirectToAction("Wishlist");
        }
        public IActionResult Wishlist()
        {

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var wishlistItems = _context.Wishlist
                .Where(item => item.UserId == userId)
                .ToList();

            var viewModel = wishlistItems.Select(item => new WishlistViewModel
            {
                Id = item.Id,
                ProductImg = item.ProductImg,
                ProductTitle = item.ProductTitle,
                ProductPrice = item.ProductPrice,
                ProductReview = item.ProductReview,
                ProductReviewRate = item.ProductReviewRate,
                ProductsArticleNumber = item.ProductsArticleNumber,
                UserId = item.UserId
            }).ToList();

            return View("Views/Partials/Wishlist/_Wishlist.cshtml", viewModel);
        }
    }
}
