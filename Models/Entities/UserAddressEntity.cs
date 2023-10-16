using System.ComponentModel.DataAnnotations;

namespace Project_Course_Submission.Models.Entities
{
    public class UserAddressEntity
    {
        [Key]
        public int Id { get; set; }

        public int AddressId { get; set; }
        public AddressEntity? Address { get; set; }

        public string UserId { get; set; } = null!;
        public UserProfileEntity? User { get; set; }
    }
}
