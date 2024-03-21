using CompanyRestaurant.DAL.Context;
using CompanyRestaurant.Entities.Entities;
using CompanyRestaurant.IOC.DependecyResolvers;
using CompanyRestaurant.MVC.AutoMappers;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddMapperService();

builder.Services.AddAutoMapper(typeof(MappingProfile));

// Add services to the container.

builder.Services.AddControllersWithViews();

// E�er kullan�caksan�z, ASP.NET Core Identity yap�land�rmas�
builder.Services.AddIdentity<AppUser, IdentityRole<int>>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.SignIn.RequireConfirmedEmail = false;
    options.Password.RequiredLength = 2;
})
.AddEntityFrameworkStores<CompanyRestaurantContext>()
.AddDefaultTokenProviders();


builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Account/Login"; // Giri� yap�lmam��sa y�nlendirilecek yol
    options.AccessDeniedPath = "/Account/AccessDenied"; // Eri�im reddedildi�inde y�nlendirilecek yol
    options.LogoutPath = "/Account/Logout"; // ��k�� i�lemi i�in yol (iste�e ba�l�)
});
//AddDbContext
builder.Services.AddRestaurantDb();

//AddRepositories
builder.Services.AddRepositoryService();
//builder.Services.AddAuthentication();
//builder.Services.AddAuthorization();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

//app.MapControllerRoute(
//    name: "areas",
//    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
//);

//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Home}/{action=Index}/{id?}"
//);

app.UseEndpoints(endpoints =>
{
    //Admin Route
    app.UseEndpoints(endpoints =>
    {
        endpoints.MapControllerRoute(
          name: "areas",
          pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
        );
    });

    //Default Route
    app.UseEndpoints(endpoints =>
    {
        endpoints.MapControllerRoute(
          name: "default",
          pattern: "{controller=Home}/{action=Index}/{id?}"
        );
    });
});

app.Run();
