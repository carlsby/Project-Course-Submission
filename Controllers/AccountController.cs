using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Project_Course_Submission.ViewModels;
using Project_Course_Submission.Services;


namespace Project_Course_Submission.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _userService;
        private readonly ITwilioService _wilioService;

        public AccountController(IUserService userService, ITwilioService wilioService)
        {
            _userService = userService;
            _wilioService = wilioService;
        }

        [Authorize]
        public IActionResult Index()
        {
            return View();
        }


        [Route("account/verification/otp")]
        public IActionResult OTP()
        {
            return View();
        }

        public IActionResult NewPassword()
        {
            return View();
        }

        public IActionResult Verification()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Verification(PhoneNumberViewModel phoneNumberViewModel)
        {
            var response = await _wilioService.SendTextVerification(phoneNumberViewModel);

            if (response.StatusCode == Enums.StatusCode.Ok)
            {
                return RedirectToAction("OTP", "Account");
            }
            else
            {
                return View();
            }
        }

        public async Task<IActionResult> Edit()
        {
            var user = await _userService.GetCurrentUserAsync(User);
            return View(user);
        }

    }
}


