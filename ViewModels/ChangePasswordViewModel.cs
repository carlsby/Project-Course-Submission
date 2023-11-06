using Microsoft.AspNetCore.Identity;
using Project_Course_Submission.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace Project_Course_Submission.ViewModels
{
    public class ChangePasswordViewModel
    {

        public string? UserId { get; set; }

        [DataType(DataType.Password)]
        public string CurrentPassword { get; set; } = null!;

        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*[^\s])(?=.*[\p{L}a-zA-Z])(?=.*[A-Z])(?=.*\d).{8,}$", ErrorMessage = "The password must be at least 8 characters long and contain at least one uppercase letter, one lowercase letter, and one digit")]
        public string NewPassword { get; set; } = null!;

        public static implicit operator IdentityUser(ChangePasswordViewModel model)
        {
            return new IdentityUser
            {
                Id = model.UserId!
            };
        }

    }

}
