using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project_Course_Submission.Services;
using Project_Course_Submission.ViewModels;

namespace Project_Course_Submission.Controllers
{
    public class LogoutController : Controller
    {
        private readonly IAuthService _auth;

        public LogoutController(IAuthService auth)
        {
            _auth = auth;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            var response = await _auth.LogoutAsync(User);

            if (response.Content)
            {
                return LocalRedirect("/");
            }
            else
            {
                return View();
            }
        }
    }
}
