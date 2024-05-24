using Microsoft.EntityFrameworkCore;
using TechNews.Models;

var builder = WebApplication.CreateBuilder(args);

// Database connection
var host = builder.Configuration["DBHOST"];
var port = builder.Configuration["DBPORT"];
var userid = builder.Configuration["DBUSERID"];
var password = builder.Configuration["DBPASSWORD"];

// Add DbContext
builder.Services.AddDbContextPool<DataContext>(options =>
{
    options.UseMySQL($"server={host};port={port};userid={userid};pwd={password};database=TechNews");
});

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Apply migrations at runtime
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<DataContext>();
    dbContext.Database.Migrate();
}

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

app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
