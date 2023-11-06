using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Project_Course_Submission.ViewModels;
using Project_Course_Submission.Services;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Project_Course_Submission.Models;

namespace Project_Course_Submission.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly IUserService _userService;
        private readonly ITwilioService _wilioService;
        private readonly UserManager<IdentityUser> _userManager;


        public AccountController(IUserService userService, ITwilioService wilioService, UserManager<IdentityUser> userManager)
        {
            _userService = userService;
            _wilioService = wilioService;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var userResponse = await _userService.GetCurrentUserAsync(User);

            if (userResponse.StatusCode == Enums.StatusCode.BadRequest)
            {
                var user = userResponse.Content;
                var serviceResponse = new ServiceResponse<UserViewModel> { Content = user };
                return View();
            }
            else
            {
                var user = userResponse.Content;
                var serviceResponse = new ServiceResponse<UserViewModel> { Content = user };
                return View(serviceResponse);
            }
        }


        [Route("account/verification/otp")]
        public IActionResult OTP()
        {
            return View();
        }

        public async Task<IActionResult> NewPassword()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> NewPassword(ChangePasswordViewModel passwordModel)
        {
            if (ModelState.IsValid)
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var changePasswordResult = await _userService.ChangePasswordAsync(userId, passwordModel.CurrentPassword, passwordModel.NewPassword);

                if (changePasswordResult.StatusCode == Enums.StatusCode.Ok)
                {
                    return RedirectToAction("Index", "Account");
                }
                else
                {
                    ModelState.AddModelError("", "Password change failed.");
                    return View(passwordModel);
                }
            }

            ModelState.AddModelError("", "Password change failed.");
            return View(passwordModel);
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

        [HttpPost]
        public async Task<IActionResult> Edit(ServiceResponse<UserViewModel> model)
        {
            var response = await _userService.EditUserAsync(model.Content!, User);

            if (response.StatusCode == Enums.StatusCode.Ok)
            {
                return RedirectToAction("Index", "Account");
            }

            return View(model);
        }

    }
}


