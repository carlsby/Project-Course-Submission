using Microsoft.AspNetCore.Identity;
using Project_Course_Submission.Models.Entities;

namespace Project_Course_Submission.ViewModels
{
    public class ChangePasswordViewModel
    {

        public string? UserId { get; set; }

        public string CurrentPassword { get; set; } = null!;
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
