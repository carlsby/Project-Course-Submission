using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Project_Course_Submission.Services;
using System.Security.Claims;

namespace Project_Course_Submission.Factories
{
    public class CustomClaimsPrincipalFactory : UserClaimsPrincipalFactory<IdentityUser>
    {
        private readonly UserService _userService;

        public CustomClaimsPrincipalFactory(UserManager<IdentityUser> userManager, IOptions<IdentityOptions> optionsAccessor, UserService userService) : base(userManager, optionsAccessor)
        {
            _userService = userService;
        }

        protected override async Task<ClaimsIdentity> GenerateClaimsAsync(IdentityUser user)
        {
            var claimsIdentity = await base.GenerateClaimsAsync(user);

            var roles = await UserManager.GetRolesAsync(user);
            claimsIdentity.AddClaims(roles.Select(x => new Claim(ClaimTypes.Role, x)));

            var userProfileEntity = await _userService.GetUserProfileAsync(user.Id);

            claimsIdentity.AddClaim(new Claim("FullName", $"{userProfileEntity.Content!.FirstName} {userProfileEntity.Content!.LastName}"));
            claimsIdentity.AddClaim(new Claim("FirstName", $"{userProfileEntity.Content!.FirstName}"));
            claimsIdentity.AddClaim(new Claim("LastName", $"{userProfileEntity.Content!.LastName}"));
            claimsIdentity.AddClaim(new Claim("Email", $"{userProfileEntity.Content!.User.Email}"));



            return claimsIdentity;
        }
    }
}
