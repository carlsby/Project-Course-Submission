using System.ComponentModel.DataAnnotations;

namespace Project_Course_Submission.Models.Entities
{
    public class FavouritesEntity
    {
        [Key]
        public int Id { get; set; }
        public UserProfileEntity? UserId { get; set; }
    }
}
