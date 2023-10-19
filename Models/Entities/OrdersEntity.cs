using Project_Course_Submission.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace Project_Course_Submission.Entities
{
    public class OrderEntity
    {
        public int Id { get; set; }  // Primary key
        public DateTime OrderDate { get; set; }
        public string OrderStatus { get; set; }
        public decimal TotalPrice { get; set; }

        // Reference to UserProfileEntity
        public UserProfileEntity? User { get; set; }

        // Navigation property to OrderItemEntity
        public List<OrderItemEntity> OrderItems { get; set; }
    }

    public class OrderItemEntity
    {
        [Key] // Specify the primary key
        public int OrderItemId { get; set; }
        public string ProductName { get; set; }
        public string Size { get; set; }
        public string Color { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        // Foreign key to the parent order
        public int OrderId { get; set; }

        // Navigation property to the parent order
        public OrderEntity Order { get; set; }
    }
}