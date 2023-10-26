using Project_Course_Submission.Models.Entities;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Project_Course_Submission.ViewModels
{
    public class UserViewModel
    {
        public string? Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? UserRoles { get; set; }
        public AddressViewModel? Address { get; set; }
        public string? PhoneNumber { get; set; }

        public static implicit operator UserProfileEntity(UserViewModel model)
        {
            return new UserProfileEntity
            {
                FirstName = model.FirstName!,
                LastName = model.LastName!,
            };
        }

        public static implicit operator IdentityUser(UserViewModel model)
        {
            return new IdentityUser
            {
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
            };
        }
    }
}
