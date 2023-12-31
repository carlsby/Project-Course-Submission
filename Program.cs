using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Project_Course_Submission.Contexts;
using Project_Course_Submission.Services;
using Project_Course_Submission.Services.Repositories;
using Project_Course_Submission.Factories;


var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<DataContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("ProductDb")));
builder.Services.AddDbContext<IdentityContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("IdentityDatabase")));
builder.Services.AddScoped<ProductService>();
builder.Services.AddScoped<CategoriesService>();
builder.Services.AddScoped<BestSellersService>();
builder.Services.AddScoped<FeaturedProductsService>();
builder.Services.AddScoped<LatestProductsService>();
builder.Services.AddScoped<ProductRepository>();


builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<ITwilioService, TwilioService>();
builder.Services.AddScoped<ReviewService>();

builder.Services.AddIdentity<IdentityUser, IdentityRole>(x =>
{
    x.SignIn.RequireConfirmedAccount = false;
    x.Password.RequiredLength = 8;
    x.User.RequireUniqueEmail = false;
})
    .AddEntityFrameworkStores<IdentityContext>()
    .AddClaimsPrincipalFactory<CustomClaimsPrincipalFactory>();



var app = builder.Build();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");



app.Run();
