using Microsoft.AspNetCore.Identity;
using Project_Course_Submission.Models.Entities;
using Project_Course_Submission.ViewModels;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace Project_Course_Submission.Models
{
    public class UserModel
    {
        public string? UserId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        public static implicit operator UserModel(UserProfileEntity model)
        {
            try
            {
                return new UserModel
                {
                    UserId = model.UserId,
                    FirstName = model.FirstName!,
                    LastName = model.LastName!,
                };
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return null!;
            }
        }
    }
}
