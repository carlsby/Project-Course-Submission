using Project_Course_Submission.Models.Entities;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Project_Course_Submission.ViewModels
{
    public class UserViewModel
    {
        public string? Id { get; set; }

        [RegularExpression("^[a-zA-ZåäöÅÄÖ]+(?:[-\\s'][a-zA-ZåäöÅÄÖ]+)*$", ErrorMessage = "Invalid characters in the name")]
        public string? FirstName { get; set; }

        [RegularExpression("^[a-zA-ZåäöÅÄÖ]+(?:[-\\s'][a-zA-ZåäöÅÄÖ]+)*$", ErrorMessage = "Invalid characters in the name")]
        public string? LastName { get; set; }

        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "You need to provide an email address")]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Invalid email format")]
        public string? Email { get; set; }

        public string? UserRoles { get; set; }
        public AddressViewModel? Address { get; set; }

        [RegularExpression(@"^\d{7,15}$", ErrorMessage = "The phone number should be 7 to 15 digits")]
        public string? PhoneNumber { get; set; }

        public static implicit operator UserProfileEntity(UserViewModel model)
        {
            return new UserProfileEntity
            {
                UserId = model.Id!,
                FirstName = model.FirstName!,
                LastName = model.LastName!,
            };
        }

        public static implicit operator IdentityUser(UserViewModel model)
        {
            return new IdentityUser
            {
                Id = model.Id!,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
            };
        }
    }
}
