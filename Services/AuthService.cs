using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Project_Course_Submission.Contexts;
using Project_Course_Submission.Models;
using Project_Course_Submission.Models.Entities;
using Project_Course_Submission.ViewModels;
using System.Security.Claims;

namespace Project_Course_Submission.Services
{
    public interface IAuthService
    {
        Task<ServiceResponse<bool>> LogInAsync(UserLoginViewModel model);
        Task<ServiceResponse<bool>> LogoutAsync(ClaimsPrincipal user);
        Task<ServiceResponse<bool>> RegisterAsync(UserRegisterViewModel model);

    }
    public class AuthService : IAuthService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IdentityContext _identityContext;

        public AuthService(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, IdentityContext identityContext)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _identityContext = identityContext;
        }

        public async Task<ServiceResponse<bool>> RegisterAsync(UserRegisterViewModel model)
        {
            var response = new ServiceResponse<bool>();

            try
            {
                IdentityUser identityUser = model;

                await _userManager.CreateAsync(identityUser, model.Password);

                UserProfileEntity userProfileEntity = new UserProfileEntity
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    UserId = identityUser.Id,
                };

                _identityContext.UserProfiles.Add(userProfileEntity);
                await _identityContext.SaveChangesAsync();
                response.Content = true;
                response.StatusCode = Enums.StatusCode.Created;

            }
            catch
            {
                response.Content = false;
                response.StatusCode = Enums.StatusCode.BadRequest;
            }

            return response;

        }

        public async Task<ServiceResponse<bool>> LogInAsync(UserLoginViewModel model)
        {
            var response = new ServiceResponse<bool>();

            try
            {
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);
                response.Content = result.Succeeded;
                response.StatusCode = result.Succeeded ? Enums.StatusCode.Ok : Enums.StatusCode.BadRequest;
            }
            catch
            {
                response.Content = false;
                response.StatusCode = Enums.StatusCode.BadRequest;
            }

            return response;
        }


        public async Task<ServiceResponse<bool>> LogoutAsync(ClaimsPrincipal user)
        {
            var response = new ServiceResponse<bool>();

            try
            {
                await _signInManager.SignOutAsync();
                response.Content = true;
                response.StatusCode = Enums.StatusCode.Ok;
            }
            catch
            {
                response.Content = false;
                response.StatusCode = Enums.StatusCode.BadRequest;
            }

            return response;
        }

    }
}
