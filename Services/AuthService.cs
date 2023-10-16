using Microsoft.AspNetCore.Identity;
using Project_Course_Submission.Contexts;
using Project_Course_Submission.Models.Entities;
using Project_Course_Submission.ViewModels;

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

                //AddressEntity addressEntity = new AddressEntity 
                //{
                //    StreetName = model.StreetName,
                //    PostalCode  = model.PostalCode,
                //    City = model.City,
                //};

                //UserAddressEntity userAddressEntity = new UserAddressEntity
                //{
                //    UserId = identityUser.Id,

                //};

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

    }
}
