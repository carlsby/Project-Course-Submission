using System.ComponentModel.DataAnnotations;

namespace Project_Course_Submission.Models.Entities
{
    public class UserPhoneNumberEntity
    {
        [Key]
        public int Id { get; set; }
        public string? PhoneNumber { get; set; }
        public bool Confirmed { get; set; }

        public string? UserId { get; set; }
        public UserProfileEntity? User { get; set; }
    }
}
