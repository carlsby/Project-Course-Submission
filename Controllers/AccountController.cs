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
        private readonly UserService _userService;

        public AccountController(UserService userService)
        {
            _userService = userService;
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
        public IActionResult Verification(PhoneNumberViewModel phoneNumberViewModel)
        {
            string accountSid = "";
            string authToken = "";

            TwilioClient.Init(accountSid, authToken);

            string fromPhoneNumber = "+13202868756";

            string toPhoneNumber = phoneNumberViewModel.PhoneNumber!;
            string messageBody = "hej";

            MessageResource.Create(
                body: messageBody,
                from: new Twilio.Types.PhoneNumber(fromPhoneNumber),
                to: new Twilio.Types.PhoneNumber(toPhoneNumber)
            );

            return RedirectToAction("OTP", "Account");
        }

        public async Task<IActionResult> Edit()
        {
            var user = await _userService.GetCurrentUserAsync(User);
            return View(user);
        }
    }
}


