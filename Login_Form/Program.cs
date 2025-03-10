using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using Login_Form;
using Login_Form.Data;
using Login_Form.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Load configuration
builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

// Retrieve the connection string
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Check if connection string is valid
if (string.IsNullOrEmpty(connectionString))
{
    throw new InvalidOperationException("❌ Connection string 'DefaultConnection' not found in appsettings.json.");
}

// Register Identity DbContext
builder.Services.AddDbContext<Login_FormContext>(options =>
    options.UseSqlServer(connectionString)
);

// Configure Identity
builder.Services.AddDefaultIdentity<Login_FormUser>(options =>
    options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<Login_FormContext>();

// Add Controllers with Views
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure Middleware
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

// Default Routing
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);
app.MapRazorPages();

app.Run();
