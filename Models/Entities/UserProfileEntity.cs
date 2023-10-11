using Microsoft.AspNetCore.Identity;
using Project_Course_Submission.ViewModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project_Course_Submission.Models.Entities
{
    public class UserProfileEntity
    {
        [Key, ForeignKey(nameof(User))]
        public string UserId { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;

        public IdentityUser User { get; set; } = null!;

        public int AddressId { get; set; }
        public UserAddressEntity Address { get; set; } = null!;

        public static implicit operator UserViewModel(UserProfileEntity model)
        {
            return new UserViewModel
            {
                FirstName = model.FirstName!,
                LastName = model.LastName!,
            };
        }
    }
}
