﻿using System.ComponentModel.DataAnnotations;

namespace Project_Course_Submission.Models.Entities
{
    public class OrdersEntity
    {
        [Key]
        public int Id { get; set; }
        public decimal TotalPrice { get; set; }
        public UserProfileEntity? UserId { get; set; }
    }
}
