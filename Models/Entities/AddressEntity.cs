using System.ComponentModel.DataAnnotations;

namespace Project_Course_Submission.Models.Entities
{
    public class AddressEntity
    {
        [Key]
        public int Id { get; set; }
        public string? Type { get; set; }
        public string? FullAddress { get; set; }
        public string? StreetName { get; set; }
        public string? PostalCode { get; set; }
        public string? City { get; set; }

    }
}
