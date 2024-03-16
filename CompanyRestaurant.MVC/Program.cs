using CompanyRestaurant.IOC.DependecyResolvers;
using CompanyRestaurant.MVC.AutoMappers;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddMapperService();

builder.Services.AddAutoMapper(typeof(MappingProfile));

// Add services to the container.

builder.Services.AddControllersWithViews();

//builder.Services.AddIdentity<AppUser, IdentityRole<int>>(x =>
//{
//    x.Password.RequireDigit = false;
//    x.Password.RequireUppercase = false;
//    x.Password.RequireLowercase = false;
//    x.Password.RequiredLength = 2;
//    x.SignIn.RequireConfirmedEmail = false;
//    x.Password.RequireNonAlphanumeric = false;


//}).AddEntityFrameworkStores<CompanyRestaurantContext>();


//DependecyResolvers

//AddDbContext
builder.Services.AddRestaurantDb();


//AddRepositories
builder.Services.AddRepositoryService();



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

app.UseAuthorization();

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
