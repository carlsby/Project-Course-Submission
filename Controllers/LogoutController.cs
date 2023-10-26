using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project_Course_Submission.Services;
using Project_Course_Submission.ViewModels;

namespace Project_Course_Submission.Controllers
{
	public class LogoutController : Controller
	{
        private readonly AuthService _auth;

        public LogoutController(AuthService auth)
        {
            _auth = auth;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            if (await _auth.LogoutAsync(User))
            {
                return LocalRedirect("/");
            }
            return RedirectToAction("Index");
        }
    }
}
