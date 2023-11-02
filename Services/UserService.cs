using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Project_Course_Submission.Contexts;
using Project_Course_Submission.Models;
using Project_Course_Submission.Models.Entities;
using Project_Course_Submission.ViewModels;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Security.Claims;

namespace Project_Course_Submission.Services
{
    public interface IUserService
    {
        Task<ServiceResponse<UserProfileEntity>> GetUserProfileAsync(string userId);
        Task<ServiceResponse<UserProfileEntity>> GetAsync(Expression<Func<UserProfileEntity, bool>> predicate);
        Task<ServiceResponse<UserViewModel>> GetCurrentUserAsync(ClaimsPrincipal claim);
        Task<ServiceResponse<ChangePasswordViewModel>> ChangePasswordAsync(string userId, string currentPassword, string newPassword);
    }

    public class UserService : IUserService
    {
        private readonly IdentityContext _identityContext;
        private readonly UserManager<IdentityUser> _userManager;

        public UserService(IdentityContext identityContext, UserManager<IdentityUser> userManager)
        {
            _identityContext = identityContext;
            _userManager = userManager;
        }

        public async Task<ServiceResponse<UserProfileEntity>> GetUserProfileAsync(string userId)
        {
            var response = new ServiceResponse<UserProfileEntity>();

            var userProfileEntity = await _identityContext.UserProfiles
                .Include(x => x.User)
                .Include(x => x.Addresses)
                .FirstOrDefaultAsync(x => x.UserId == userId);

            if (userProfileEntity != null)
            {
                response.StatusCode = Enums.StatusCode.Ok;
                response.Content = userProfileEntity;
            }
            else
            {
                response.StatusCode = Enums.StatusCode.BadRequest;
            }

            return response;
        }

        public async Task<ServiceResponse<UserProfileEntity>> GetAsync(Expression<Func<UserProfileEntity, bool>> predicate)
        {
            var response = new ServiceResponse<UserProfileEntity>();

            var userProfile = await _identityContext.UserProfiles.Include(x => x.Addresses).FirstOrDefaultAsync(predicate);

            if (userProfile != null)
            {
                response.StatusCode = Enums.StatusCode.Ok;
                response.Content = userProfile;
            }
            else
            {
                response.StatusCode = Enums.StatusCode.BadRequest;
            }

            return response;
        }

        public async Task<ServiceResponse<UserViewModel>> GetCurrentUserAsync(ClaimsPrincipal claim)
        {
            try
            {
                UserViewModel userViewModel = new();
                AddressViewModel addressViewModel = new();
                var response = new ServiceResponse<UserViewModel>();

                var user = await _userManager.FindByEmailAsync(claim.Identity!.Name!);

                if (user != null)
                {
                    var profile = await GetAsync(x => x.UserId == user.Id);

                    userViewModel = profile.Content!;
                    userViewModel.Email = user.UserName;
                    userViewModel.PhoneNumber = user.PhoneNumber;
                    response.Content = userViewModel;
                }
                return response;
            }
            catch { return null!; }
        }

        public async Task<ServiceResponse<ChangePasswordViewModel>> ChangePasswordAsync(string userId, string currentPassword, string newPassword)
        {
            var response = new ServiceResponse<ChangePasswordViewModel>();
            var identityUser = await _userManager.FindByIdAsync(userId);

            if (identityUser == null)
            {
                response.StatusCode = Enums.StatusCode.Notfound;
                return response;
            }

            var result = await _userManager.ChangePasswordAsync(identityUser, currentPassword, newPassword);

            if (result.Succeeded)
            {
                response.Content = new ChangePasswordViewModel();
                response.StatusCode = Enums.StatusCode.Ok;
            }
            else
            {
                response.StatusCode = Enums.StatusCode.BadRequest;
            }

            return response;
        }


    }
}
