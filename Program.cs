using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Project_Course_Submission.Contexts;
<<<<<<< HEAD
using Project_Course_Submission.Services;
using Project_Course_Submission.Services.Repositories;
=======
using Project_Course_Submission.Factories;
using Project_Course_Submission.Services;
>>>>>>> 765f9a27614e7be52b977be282b6195029b184cc

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<DataContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("ProductsDB")));
builder.Services.AddDbContext<IdentityContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("IdentityDb")));
builder.Services.AddScoped<ProductService>();
builder.Services.AddScoped<CategoriesService>();
builder.Services.AddScoped<BestSellersService>();
builder.Services.AddScoped<FeaturedProductsService>();
builder.Services.AddScoped<ProductRepository>();

<<<<<<< HEAD
=======
builder.Services.AddDbContext<IdentityContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("IdentityDatabase")));
builder.Services.AddDbContext<DataContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("IdentityDatabase")));


builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<AuthService>();

builder.Services.AddIdentity<IdentityUser, IdentityRole>(x =>
{
    x.SignIn.RequireConfirmedAccount = false;
    x.Password.RequiredLength = 8;
    x.User.RequireUniqueEmail = false;
})
    .AddEntityFrameworkStores<IdentityContext>()
    .AddClaimsPrincipalFactory<CustomClaimsPrincipalFactory>();

>>>>>>> 765f9a27614e7be52b977be282b6195029b184cc

var app = builder.Build();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");



app.Run();
