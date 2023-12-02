using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Raythos_Aerospace.Data;
//using Raythos_Aerospace.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<Raythos_AerospaceContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Raythos_AerospaceContext") ?? throw new InvalidOperationException("Connection string 'Raythos_AerospaceContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();

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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
