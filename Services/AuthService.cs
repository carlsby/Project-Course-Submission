using Microsoft.AspNetCore.Identity;
using Project_Course_Submission.Contexts;
using Project_Course_Submission.Models.Entities;
using Project_Course_Submission.ViewModels;
using System.Security.Claims;

namespace Project_Course_Submission.Services
{
    public class AuthService
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

        public async Task<bool> RegisterAsync(UserRegisterViewModel model)
        {
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

                return true;
            }catch { return false; }
            
        }

        public async Task<bool> LogInAsync(UserLoginViewModel model)
        {
            try
            {
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);

                return result.Succeeded;
            }
            catch { return false; }
        }

        public async Task<bool> LogoutAsync(ClaimsPrincipal user)
        {
            await _signInManager.SignOutAsync();

            return _signInManager.IsSignedIn(user);
        }

    }
}
