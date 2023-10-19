using Project_Course_Submission.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace Project_Course_Submission.Entities
{
    public class OrderEntity
    {
        [Key]
        public int Id { get; set; }  
        public DateTime OrderDate { get; set; }
        public string OrderStatus { get; set; }
        public decimal TotalPrice { get; set; }


        public UserProfileEntity? User { get; set; }
        public string UserId { get; set; }

        public List<OrderItemEntity> OrderItems { get; set; }
    }

    public class OrderItemEntity
    {
        [Key] 
        public int OrderItemId { get; set; }
        public string ProductName { get; set; }
        public string Size { get; set; }
        public string Color { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public int OrderId { get; set; }

    
        public OrderEntity Order { get; set; }
    }

    public class OrderTrackEntity
    {
        [Key]
        public int TrackId { get; set; }
        public string? EstimatedDate { get; set; }
        public string TrackDescription { get; set; }
        public bool IsDot { get; set; }
        public string TrackLabel { get; set; }

        public int OrderId { get; set; }
        public OrderEntity Order { get; set; }
    }


}
