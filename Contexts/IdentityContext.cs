using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Project_Course_Submission.Models.Entities;

namespace Project_Course_Submission.Contexts;

public class IdentityContext : IdentityDbContext
{
    public IdentityContext(DbContextOptions<IdentityContext> options) : base(options)
    {
    }

    public DbSet<UserProfileEntity> UserProfiles { get; set; }
    public DbSet<UserAddressEntity> UserAddress { get; set; }
}
