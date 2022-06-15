using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Seren.UP.Intranet.Data;
var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("SerenUPIntranetContextConnection") ?? throw new InvalidOperationException("Connection string 'SerenUPIntranetContextConnection' not found.");

builder.Services.AddDbContext<SerenUPIntranetContext>(options =>
    options.UseSqlServer(connectionString));;

builder.Services.AddIdentity<ApplicationUser, ApplicationRole>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<SerenUPIntranetContext>().AddDefaultUI().AddDefaultTokenProviders(); ;

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
