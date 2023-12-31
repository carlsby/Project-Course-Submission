﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Project_Course_Submission.Contexts;
using Project_Course_Submission.Models;
using Project_Course_Submission.Models.Entities;
using Project_Course_Submission.ViewModels;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;

namespace Project_Course_Submission.Services
{
    public interface IUserService
    {
        Task<ServiceResponse<UserViewModel>> EditUserAsync(UserViewModel model, ClaimsPrincipal claim);
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

                var user = claim.FindFirstValue("Id");

                var userProfileEntity = await _identityContext.UserProfiles
                    .Include(x => x.User)
                    .Include(x => x.Addresses)
                    .FirstOrDefaultAsync(x => x.User.Id == user);

                if (user != null)
                {
                    var profile = await GetAsync(x => x.User.Id == user);

                    userViewModel = profile.Content!;
                    userViewModel.Email = profile.Content.User.Email;
                    userViewModel.PhoneNumber = profile.Content.User.PhoneNumber;
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

        public async Task<ServiceResponse<UserViewModel>> EditUserAsync(UserViewModel model, ClaimsPrincipal claim)
        {
            var response = new ServiceResponse<UserViewModel>();

            try
            {
                var currentUserResponse = claim.FindFirstValue("Id");

                var userProfileEntity = await _identityContext.UserProfiles
                    .Include(x => x.User)
                    .Include(x => x.Addresses)
                    .FirstOrDefaultAsync(x => x.User.Id == currentUserResponse);

                if (userProfileEntity != null)
                {
                    userProfileEntity.FirstName = model.FirstName!;
                    userProfileEntity.LastName = model.LastName!;
                    userProfileEntity.User.Email = model.Email;
                    userProfileEntity.User.UserName = model.Email;
                    userProfileEntity.User.PhoneNumber = model.PhoneNumber;


                    response.StatusCode = Enums.StatusCode.Ok;

                    await _userManager.SetEmailAsync(userProfileEntity.User, model.Email);

                    await _identityContext.SaveChangesAsync();
                }
                else
                {
                    response.StatusCode = Enums.StatusCode.BadRequest;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }

            return response;
        }

    }
}
