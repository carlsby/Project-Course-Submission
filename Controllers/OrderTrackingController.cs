﻿using Microsoft.AspNetCore.Mvc;

namespace Project_Course_Submission.Controllers
{
    public class OrderTrackingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Tracking()
        {
            
            return View("Views/Partials/OrderTracking/_Tracking.cshtml"); 
        }
    }
}
