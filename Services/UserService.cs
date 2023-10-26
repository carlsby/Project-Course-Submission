using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Project_Course_Submission.Contexts;
using Project_Course_Submission.Models;
using Project_Course_Submission.Models.Entities;
using Project_Course_Submission.ViewModels;
using System.Linq.Expressions;
using System.Security.Claims;

namespace Project_Course_Submission.Services
{
    public interface IUserService
    {
        Task<ServiceResponse<UserProfileEntity>> GetUserProfileAsync(string userId);

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

        public async Task<UserProfileEntity> GetAsync(Expression<Func<UserProfileEntity, bool>> predicate)
        {
            var userProfile = await _identityContext.UserProfiles.Include(x => x.Addresses).FirstOrDefaultAsync(predicate);

            return userProfile!;
        }

        public async Task<UserViewModel> GetCurrentUserAsync(ClaimsPrincipal claim)
        {
            try
            {
                UserViewModel userViewModel = new();
                AddressViewModel addressViewModel = new();

                var user = await _userManager.FindByEmailAsync(claim.Identity!.Name!);

                if (user != null)
                {
                    var profile = await GetAsync(x => x.UserId == user.Id);

                    userViewModel = profile;
                    userViewModel.Email = user.UserName;
                    userViewModel.PhoneNumber = user.PhoneNumber;
                }
                return userViewModel;
            }
            catch { return null!; }
        }
    }
}
