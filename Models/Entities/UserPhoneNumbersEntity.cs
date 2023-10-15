﻿using System.ComponentModel.DataAnnotations;

namespace Project_Course_Submission.Models.Entities
{
    public class UserPhoneNumbersEntity
    {
        public int Id { get; set; }

        public int PhoneNumberId { get; set; }
        public PhoneNumberEntity? PhoneNumber { get; set; }

        public string UserId { get; set; } = null!;
        public UserProfileEntity? User { get; set; }
    }
}
