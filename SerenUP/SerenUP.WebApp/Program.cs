using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SerenUP.WebApp.Data;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("SerenUPWebAppContextConnection") ?? throw new InvalidOperationException("Connection string 'SerenUPWebAppContextConnection' not found.");
var services = builder.Services;
var configuration = builder.Configuration;

//services.AddDbContext<SerenUPWebAppContext>();
builder.Services.AddDbContext<SerenUPWebAppContext>(options =>
    options.UseSqlServer(connectionString));;

builder.Services.AddIdentity<ApplicationUser, ApplicationRole>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
    options.Password.RequiredLength = 10;
    options.Password.RequireLowercase = true;
    options.Password.RequireUppercase = true;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequireDigit = false;
})
    .AddRoles<ApplicationRole>()
    .AddEntityFrameworkStores<SerenUPWebAppContext>()
    .AddDefaultUI()
    .AddDefaultTokenProviders(); ;

//Google authentication
services.AddAuthentication().AddGoogle(googleOptions =>
{
    googleOptions.ClientId = configuration["Authentication:Google:ClientId"];
    googleOptions.ClientSecret = configuration["Authentication:Google:ClientSecret"];
});

//Facebook authentication
services.AddAuthentication().AddFacebook(facebookOptions =>
{
    facebookOptions.AppId = configuration["Authentication:Facebook:AppId"];
    facebookOptions.AppSecret = configuration["Authentication:Facebook:AppSecret"];
});

// add service for personalize database 
/*services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
        .AddEntityFrameworkStores<SerenUPWebAppContext>();*/
/*services.AddIdentity<ApplicationUser, ApplicationRole>(options => options.SignIn.RequireConfirmedAccount = true)
        .AddEntityFrameworkStores<SerenUPWebAppContext>()
        .AddDefaultUI()
        .AddDefaultTokenProviders();*/




// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();;

app.UseAuthorization();

app.MapRazorPages();

app.Run();
