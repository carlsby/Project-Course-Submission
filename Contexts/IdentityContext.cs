using Microsoft.AspNetCore.Identity;
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
    public DbSet<UserPhoneNumbersEntity> UserPhoneNumber { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Ignore<IdentityRole>();
        modelBuilder.Ignore<IdentityUserToken<string>>();
        modelBuilder.Ignore<IdentityUserRole<string>>();
        modelBuilder.Ignore<IdentityUserLogin<string>>();
        modelBuilder.Ignore<IdentityUserClaim<string>>();
        modelBuilder.Ignore<IdentityRoleClaim<string>>();
        modelBuilder.Entity<IdentityUser>()
            .Ignore(c => c.PhoneNumber)
            .Ignore(c => c.PhoneNumberConfirmed);


        modelBuilder.Entity<IdentityUser>().ToTable("Users");

    }
}
